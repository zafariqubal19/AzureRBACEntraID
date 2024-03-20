using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.Contacts;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.References;
using RSCS.FinancingStatements.Core.Services;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System.ComponentModel.Design;
using System.Security.Principal;
using RSCS.FinancingStatements.Core.Models.RequestParameters;
using RSCS.FinancingStatements.Shared.ResponseHandler;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using System.Reflection.Metadata;
using RSCS.FinancingStatements.API.Common;

namespace RSCS.FinancingStatements.API.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = ApiConstant.SecurityAccess)]
    [RequiredScope("FinancingStatementScope")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IReferencesService _referenceService;
        private readonly IContactsService _contactsService;
        private readonly IResourceSecurityService _resourceSecurityService;

        public SecurityController(ILogger<SecurityController> logger, IReferencesService referenceService,
            IContactsService contactsService, IResourceSecurityService resourceSecurityService)
        {
            _logger = logger;
            _referenceService = referenceService;
            _contactsService = contactsService;
            _resourceSecurityService = resourceSecurityService;
        }
        [HttpGet]
        [Route("getReference")]
        //[Authorize(Roles = "FullAccess,ReadWrite,ReadOnly")]
        [Authorize(Roles =ApiConstant.Read)]
        //[Authorize(Policy = "ReadOnly")]
        public APIResponse GetReferences()
        {
            try
            {
                _logger.LogInformation($"GetReferences is fetched");
                IEnumerable<References> references = _referenceService.FetchReferences().Result;
                return new APIResponse((int)HttpStatusCode.OK, "Reference list", references);

            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"GetReferences has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "Reference list", null, apiError);

            }

        }
        [HttpGet]
        // [Authorize(Roles = "FullAccess,ReadWrite,ReadOnly")]
         [Authorize(Roles =ApiConstant.Read)]
       // [Authorize(Policy = "ReadOnly")]
        [Route("getContacts")]
        public APIResponse GetContacts(int MasterID)
        {

            try
            {
                _logger.LogInformation($"GetContacts is fetched");
                IEnumerable<Contacts> contacts = _contactsService.FetchContacts(MasterID).Result;
                return new APIResponse((int)HttpStatusCode.OK, "Contact list", contacts);
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"GetContacts has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "Contact list", null, apiError);
            }
        }
        [HttpPut]
        [Route("grantOrRestrictAccess")]
        //[Authorize(Roles = "FullAccess,ReadWrite")]
        [Authorize(Roles =ApiConstant.Write)]
        //[Authorize(Policy = "ReadWrite")]
        public APIResponse GrantOrRestrictAccess(GrantOrRestrict grantOrRestrict)
        {
            try
            {
                _logger.LogInformation($"GrantOrRestrictAccess is fetched");
                int effectedRow = _resourceSecurityService.SecurityAcces(grantOrRestrict).Result;
                if (grantOrRestrict.ResourceSecurityValue == "A")
                {
                    return new APIResponse((int)HttpStatusCode.OK, "Access Granted ", effectedRow);
                }
                else
                {
                    return new APIResponse((int)HttpStatusCode.OK, "Access Restricted ", effectedRow);
                }

            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"GrantOrRestrictAccess has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "Grant or access has some error", null, apiError);
            }


        }
    }
}
