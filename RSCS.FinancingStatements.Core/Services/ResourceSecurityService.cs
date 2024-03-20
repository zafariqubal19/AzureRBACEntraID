using RSCS.FinancingStatements.Core.Models.BusinessObjects.ResourceSecurity;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSCS.FinancingStatements.Core.Models.RequestParameters;

namespace RSCS.FinancingStatements.Core.Services
{
    public class ResourceSecurityService : IResourceSecurityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResourceSecurityRepository _resourceSecurityRepository;

        public ResourceSecurityService(IUnitOfWork unitOfWork, IResourceSecurityRepository resourceSecurityRepository)
        {
            _unitOfWork = unitOfWork;
            _resourceSecurityRepository = resourceSecurityRepository;
        }
        public async Task<int> SecurityAcces(GrantOrRestrict grantRestrictParameter)
        {
            string Comments = grantRestrictParameter.Contact;
            object param = new
            {
                grantRestrictParameter.NameID,
                grantRestrictParameter.ResourceSecurityTypeID,
                grantRestrictParameter.ResourceSecurityValue,
                grantRestrictParameter.LastModifiedBy,
                grantRestrictParameter.Contact
            };
            string SQLQuery = $" exec p_Attendance_UpdateResourceSecurity @nameId={grantRestrictParameter.NameID},@resourceSecurityTypeId={grantRestrictParameter.ResourceSecurityTypeID},@resourceSecurityValue='{grantRestrictParameter.ResourceSecurityValue}',@lastModifiedBy='{grantRestrictParameter.LastModifiedBy}',@contact='{grantRestrictParameter.Contact}'";
            int EffectedRow = await _resourceSecurityRepository.UpdateAsync(SQLQuery);
            _unitOfWork.Commit();
            return EffectedRow;
        }
    }
}
