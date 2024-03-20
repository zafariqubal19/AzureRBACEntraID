using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Data.Persistance.DataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDBTransactionFactory _dbTransactionFactory;
		private readonly IDbConnection _dbConnection;

		public UnitOfWork(IDBTransactionFactory dBTransactionFactory, IDbConnection dbConnection)
		{
			_dbTransactionFactory = dBTransactionFactory;
			_dbConnection = dbConnection;
		}

		public void Commit()
		{
			try
			{
				_dbTransactionFactory.HandleCommit();
			}
			catch (Exception ex)
			{
				_dbTransactionFactory.HandleRollback();
			}
		}

		public void Dispose()
		{
			//Close the SQL Connection and dispose the objects
			_dbTransactionFactory.HandleDispose();
		}
	}
}
