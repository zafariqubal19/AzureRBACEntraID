using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinPrograms;
using RSCS.FinancingStatements.Core.Models.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IFinProgramsService
    {
        Task<IEnumerable<FinPrograms>> FetchFinprograms();
        Task<int> UpdateFinProgram(FinProgramRequestParameter finProgramRequestParameter);



    }
}
