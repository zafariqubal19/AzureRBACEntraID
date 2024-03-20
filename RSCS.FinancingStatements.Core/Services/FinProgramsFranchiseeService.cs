using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinProgramsFranchisee;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Services
{
    public class FinProgramsFranchiseeService : IFinProgramsFranchiseeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFinProgramsFranchiseeRepository _finProgramsFranchiseeRepository;

        public FinProgramsFranchiseeService(IUnitOfWork unitOfWork, IFinProgramsFranchiseeRepository finProgramsFranchiseeRepository)
        {
            _unitOfWork = unitOfWork;
            _finProgramsFranchiseeRepository = finProgramsFranchiseeRepository;
        }

        public async Task<IEnumerable<FinProgramsFranchisee>> FetchFinProgramFranchisee(int ProgramId)
        {

            string query = "p_FinProgFranchisee_GetFranchisee";
            object param = new { ProgramId };
            List<FinProgramsFranchisee> finProgramsFranchisees = new List<FinProgramsFranchisee>();

            foreach (var finProgramsFranchiseeEntity in await _finProgramsFranchiseeRepository.GetAllAsync(query, param))
            {
                finProgramsFranchisees.Add(finProgramsFranchiseeEntity.ToBusinessObject());
            }
            return finProgramsFranchisees;
        }
    }
}
