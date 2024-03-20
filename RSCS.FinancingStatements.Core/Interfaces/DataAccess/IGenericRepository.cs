using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.DataAccess
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> GetAllAsync(string SQLquery, CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> GetAllAsync(string SQLquery, object param, CancellationToken cancellationToken = default);
        Task<T> GetAsync(object id, CancellationToken cancellationToken = default);
		Task<T> GetAsync(string SQLquery, object? param=null!, CancellationToken cancellationToken = default);
        Task InsertAsync(T t, CancellationToken cancellationToken = default);
		void InsertBulk(IEnumerable<T> items);
		Task UpdateAsync(T t, CancellationToken cancellationToken = default);
		Task<int> UpdateAsync(string SQLQuery, object? param = null!, CommandType? commandType = null!, CancellationToken cancellationToken = default);
        Task DeleteAsync(object id, CancellationToken cancellationToken = default);
		Task InsertRangeAsync(IEnumerable<T> t, CancellationToken cancellationToken = default);
		

    }
}
