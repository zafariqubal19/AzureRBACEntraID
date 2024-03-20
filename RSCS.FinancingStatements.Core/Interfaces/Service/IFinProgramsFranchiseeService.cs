using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinProgramsFranchisee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IFinProgramsFranchiseeService
    {
        Task<IEnumerable<FinProgramsFranchisee>> FetchFinProgramFranchisee(int ProgramId);
    }
}
