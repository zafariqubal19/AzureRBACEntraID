using RSCS.FinancingStatements.Core.Models.BusinessObjects.References;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Services
{
    public class ReferencesService : IReferencesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReferencesRepository _referencesRepository;

        public ReferencesService(IUnitOfWork unitOfWork, IReferencesRepository referencesRepository)
        {
            _unitOfWork = unitOfWork;
            _referencesRepository = referencesRepository;
        }
        public async Task<IEnumerable<References>> FetchReferences()
        {

            string SQLQuery = "p_FinProgFranchisee_ReferenceCount";
            List<References> references = new List<References>();
            foreach (var referenceEntities in await _referencesRepository.GetAllAsync(SQLQuery))
            {
                references.Add(referenceEntities.ToBusinessObject());
            }
            return references;
        }
    }
}
