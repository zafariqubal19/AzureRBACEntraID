using RSCS.FinancingStatements.Core.Models.BusinessObjects.StatementDetails;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Services
{
    public class StatementDetailsService : IStatementDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementDetailsRepository _statementDetailsRepository;

        public StatementDetailsService(IUnitOfWork unitOfWork, IStatementDetailsRepository statementDetailsRepository)
        {
            _statementDetailsRepository = statementDetailsRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<StatementDetails>> FetchStatementDetails(int programId, string masterId)
        {
            string query = "p_FinProgStatements_GetStatements ";
            object param = new { programId, masterId };
            List<StatementDetails> statementDetails = new List<StatementDetails>();
            foreach (var statementDetailsentity in await _statementDetailsRepository.GetAllAsync(query, param))
            {
                statementDetails.Add(statementDetailsentity.ToBusinessObject());
            }
            return statementDetails;
        }
    }
}
