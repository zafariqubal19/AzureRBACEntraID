using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.DataAccess
{
	public interface IDBTransactionFactory
	{
		IDbTransaction Get();
		void HandleCommit();
		void HandleRollback();
		void HandleDispose();
	}
}
