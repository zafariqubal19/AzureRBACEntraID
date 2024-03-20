using Microsoft.Data.SqlClient;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Data.Persistance.DataAccess
{
	public class DBTransactionFactory : IDBTransactionFactory
	{
		private IDbTransaction _transaction;
		private readonly IDbConnection _dbConnection;

		public DBTransactionFactory(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public IDbTransaction Get()
		{
			if (_transaction == null)
				_transaction = GenerateSqlTransaction();

			return _transaction;
		}

		public void HandleCommit()
		{
			_transaction.Commit();
			HandleDispose();
			_transaction = GenerateSqlTransaction();
		}

		public void HandleRollback()
		{
			_transaction.Rollback();
			HandleDispose();
			_transaction = GenerateSqlTransaction();
		}

		public void HandleDispose()
		{
			_transaction?.Connection?.Close();
			_transaction?.Connection?.Dispose();
			_transaction?.Dispose();
		}

		private SqlTransaction GenerateSqlTransaction()
		{
			SqlConnection conn = (SqlConnection)_dbConnection;
			if (conn.State != ConnectionState.Open) conn.Open();
			return conn.BeginTransaction();
		}
	}
}
