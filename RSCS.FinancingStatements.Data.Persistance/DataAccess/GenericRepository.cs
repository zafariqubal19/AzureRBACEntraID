using Dapper;
using Microsoft.Extensions.Configuration;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinPrograms;
using RSCS.FinancingStatements.Data.Persistance.Extensions;
using RSCS.FinancingStatements.Data.Persistance.Helpers;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Data.Persistance.DataAccess
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDBTransactionFactory _dbTransactionFactory;

        private readonly IConfiguration _configuration;
        private static IEnumerable<string> _listOfProperties;
        private static string _selectFields = string.Empty;

        private readonly string _connectionString;
        private readonly string _tableName;

        static GenericRepository()
        {
            _listOfProperties = GenerateListOfProperties(typeof(T).GetProperties());
        }

        protected GenericRepository(IDbConnection dbConnection, IDBTransactionFactory dbTransactionFactory)
        {
            _dbConnection = dbConnection;
            _dbTransactionFactory = dbTransactionFactory;

            _tableName = $"[{typeof(T).Name}]";
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await LoadFields(async () =>
            {
                return await _dbConnection.QueryAsyncWithToken<T>($"SELECT {_selectFields} FROM {_tableName}",
                    new { },
                    _dbTransactionFactory.Get(),
                    cancellationToken: cancellationToken);
            }, true);
        }
        public async Task<IEnumerable<T>> GetAllAsync(string SQLquery, CancellationToken cancellationToken = default)
        {

            return await LoadFields(async () =>
            {
                return await _dbConnection.QueryAsyncWithToken<T>(SQLquery,
                    new { },
                    _dbTransactionFactory.Get(),
                    30,
                    cancellationToken: cancellationToken);
            }, true);
        }
        public async Task<IEnumerable<T>> GetAllAsync(string SQLquery, object param, CancellationToken cancellationToken = default)
        {

            return await LoadFields(async () =>
            {
                return await _dbConnection.QueryAsyncWithToken<T>(SQLquery,
                    param,
                    _dbTransactionFactory.Get(),
                    30,
                    CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
            }, true);
        }

        public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
        {
            return await LoadFields(async () =>
            {
                var result =
                    await _dbConnection.QuerySingleOrDefaultWithToken<T>($"SELECT {_selectFields} FROM {_tableName} WHERE Id=@Id",
                        new { Id = id },
                        _dbTransactionFactory.Get(),
                        cancellationToken: cancellationToken);
                if (result == null) throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");
                return result;
            }, true);
        }
        public async Task<T> GetAsync(string SQLquery, object? param = null!, CancellationToken cancellationToken = default)
        {
            return await LoadFields(async () =>
            {
                var result =
                    await _dbConnection.QuerySingleOrDefaultWithToken<T>(SQLquery,
                       new { param },
                        _dbTransactionFactory.Get(),
                        cancellationToken: cancellationToken);
                if (result == null) throw new KeyNotFoundException($"{_tableName} with id [{param}] could not be found.");
                return result;
            }, true);
        }

        public async Task InsertAsync(T t, CancellationToken cancellationToken = default)
        {
            var insertQuery = GenerateInsertQuery();
            var result = await _dbConnection.ExecuteAsyncWithToken(insertQuery, t,
                _dbTransactionFactory.Get(),
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            Console.Write(result);
        }

        //The bulk copy operation occurs in a non-transacted way, with no opportunity for rolling it back.
        public void InsertBulk(IEnumerable<T> items)
        {
            var dataTable = BulkInsertHelpers.CreateDataTable<T>(items);
            using var bulkInsert = new Microsoft.Data.SqlClient.SqlBulkCopy(_connectionString);
            bulkInsert.DestinationTableName = _tableName;
            bulkInsert.WriteToServer(dataTable);
        }

        public async Task UpdateAsync(T t, CancellationToken cancellationToken = default)
        {
            var updateQuery = GenerateUpdateQuery();
            await _dbConnection.ExecuteAsyncWithToken(updateQuery, t,
                _dbTransactionFactory.Get(),
                cancellationToken: cancellationToken);
        }
        public async Task<int> UpdateAsync(string SQLQuery, object? param = null!, CommandType? commandType = null!, CancellationToken cancellationToken = default)
        {
            var updateQuery = SQLQuery;
            return await _dbConnection.ExecuteAsyncWithToken(updateQuery,
                  new { param }, _dbTransactionFactory.Get(), 10, commandType, cancellationToken);
        }

        public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            await _dbConnection.ExecuteAsyncWithToken($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = id },
                _dbTransactionFactory.Get(),
                cancellationToken: cancellationToken);
        }

        //uses transaction
        public async Task InsertRangeAsync(IEnumerable<T> t, CancellationToken cancellationToken = default)
        {
            var insertQuery = GenerateInsertQuery();
            await _dbConnection.ExecuteAsyncWithToken(insertQuery, t,
                _dbTransactionFactory.Get(),
                cancellationToken: cancellationToken);
        }

        #region PrivateHelperMethods

        private Microsoft.Data.SqlClient.SqlConnection SqlConnection()
        {
            return new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
        }

        /// <summary>
        /// Open new connection and return it for use
        /// </summary>
        /// <returns></returns>
        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        private TU LoadFields<TU>(Func<TU> method, bool includeId = false)
        {
            if (string.IsNullOrEmpty(_selectFields)) _selectFields = GenerateSelectFields(_listOfProperties, includeId);
            return method.Invoke();
        }

        private static IEnumerable<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        private void IgnoreId(string property, Action action)
        {
            if (!property.Equals("Id")) action.Invoke();
        }

        private string GenerateSelectFields(IEnumerable<string> properties, bool includeId)
        {
            var fields = new StringBuilder();
            foreach (var property in properties)
            {
                if (includeId == false)
                {
                    IgnoreId(property, () => { fields.Append($"{property},"); });
                }
                else
                {
                    fields.Append($"{property},");
                }
            }

            fields.Remove(fields.Length - 1, 1);
            return fields.ToString();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");
            foreach (var listOfProperty in _listOfProperties)
            {
                //TODO: extract this check
                IgnoreId(listOfProperty, () => { insertQuery.Append($"[{listOfProperty}],"); });
            }

            insertQuery.Remove(insertQuery.Length - 1, 1).Append(") VALUES (");

            foreach (var listOfProperty in _listOfProperties)
            {
                IgnoreId(listOfProperty, () => { insertQuery.Append($"@{listOfProperty},"); });
            }

            insertQuery.Remove(insertQuery.Length - 1, 1).Append(")");

            return insertQuery.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");

            foreach (var listOfProperty in _listOfProperties)
            {
                IgnoreId(listOfProperty, () => { updateQuery.Append($"{listOfProperty}=@{listOfProperty},"); });
            }

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        #endregion
    }
}
