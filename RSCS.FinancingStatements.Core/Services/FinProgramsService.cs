using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinPrograms;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSCS.FinancingStatements.Core.Models.RequestParameters;

namespace RSCS.FinancingStatements.Core.Services
{
    public class FinProgramsService : IFinProgramsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFinProgramsRepository _finProgramsRepository;

        public FinProgramsService(IUnitOfWork unitOfWork, IFinProgramsRepository finProgramsRepository)
        {
            _unitOfWork = unitOfWork;
            _finProgramsRepository = finProgramsRepository;
        }
        public async Task<IEnumerable<FinPrograms>> FetchFinprograms()
        {

            var query = "p_FinPrograms_GetFinPrograms";
            List<FinPrograms> finprograms = new List<FinPrograms>();
            foreach (var finprogramsEntity in await _finProgramsRepository.GetAllAsync(query))
            {
                finprograms.Add(finprogramsEntity.ToBusinessObject());
            }
            return finprograms;
        }


        public async Task<int> UpdateFinProgram(FinProgramRequestParameter finProgramRequestParameter)
        {

            int ActiveOnWeb = 0;
            int ActiveToProcess = 0;

            if (finProgramRequestParameter.ActiveProcess == "on" || finProgramRequestParameter.ActiveProcess == "Active")
            {
                ActiveToProcess = 1;
            }
            if (finProgramRequestParameter.ActiveWeb == "on" || finProgramRequestParameter.ActiveWeb == "Active")
            {
                ActiveOnWeb = 1;
            }

            string SQLQuery = $"exec p_finprograms_UpdateFinprograms @ProgramID='{finProgramRequestParameter.ProgramId}', @StartDate='{finProgramRequestParameter.StartDate}',@EndDate='{finProgramRequestParameter.EndDate}',@ActiveOnWeb='{ActiveOnWeb}',@ActiveToProcess='{ActiveToProcess}',@PaymentTermsCode='{finProgramRequestParameter.PaymentTermsCode}',@Comments='{finProgramRequestParameter.Comments}'";
            int effectedRows = await _finProgramsRepository.UpdateAsync(SQLQuery);
            _unitOfWork.Commit();
            return effectedRows;

        }


    }
}
