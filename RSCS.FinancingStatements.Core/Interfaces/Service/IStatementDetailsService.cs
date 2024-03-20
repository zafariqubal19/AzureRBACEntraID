using RSCS.FinancingStatements.Core.Models.BusinessObjects.StatementDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IStatementDetailsService
    {
        Task<IEnumerable<StatementDetails>> FetchStatementDetails(int programId, string masterId);
    }
}
