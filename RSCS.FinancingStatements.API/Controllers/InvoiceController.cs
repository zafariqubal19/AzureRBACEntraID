using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinPrograms;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.FinProgramsFranchisee;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.InvoiceDetails;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.StatementDetails;
using RSCS.FinancingStatements.Core.Services;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using RSCS.FinancingStatements.Shared.ResponseHandler;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using RSCS.FinancingStatements.API.Common;

namespace RSCS.FinancingStatements.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [RequiredScope("FinancingStatementScope")]
    [ApiController]
    //[Authorize(Roles = ApiConstant.InvoiceAccess)]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IFinProgramsService _finProgramsService;
        private readonly IFinProgramsFranchiseeService _finProgramsFranchiseeService;
        private readonly IInvoiceDetailsService _invoiceDetailsService;
        private readonly IStatementDetailsService _StatementDetailsService;
        private readonly IConfiguration _configuration;

        public InvoiceController(ILogger<InvoiceController> logger, IFinProgramsService finProgramsService,
            IFinProgramsFranchiseeService finProgramsFranchiseeService, IInvoiceDetailsService invoiceDetailsService,
            IStatementDetailsService statementDetailsService, IConfiguration configuration)
        {
            _logger = logger;
            _finProgramsService = finProgramsService;
            _finProgramsFranchiseeService = finProgramsFranchiseeService;
            _invoiceDetailsService = invoiceDetailsService;
            _StatementDetailsService = statementDetailsService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getFinPrograms")]
        //[Authorize(Roles = "ReadOnly,ReadWrite,FullAccess")]
        [Authorize(Roles =ApiConstant.Read)]
        //[Authorize(Policy ="ReadOnly")]
        public APIResponse getFinPrograms()
        {

            try
            {
                _logger.LogInformation($"getFinPrograms is fetched");
                IEnumerable<FinPrograms> finPrograms = _finProgramsService.FetchFinprograms().Result;
                return new APIResponse((int)HttpStatusCode.OK, "FinProgramList", finPrograms);

            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"getFinPrograms has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "ProgramList", null, apiError);

            }


        }
        [HttpGet]
        [Route("getFinProgramsFranchisee")]
        //[Authorize(Roles = "ReadOnly,ReadWrite,FullAccess")]
        [Authorize(Roles =ApiConstant.Read)]
        //[Authorize(Policy = "ReadOnly")]
        public APIResponse GetFinProgramsFranchisees(int ProgramId)
        {
            try
            {
                _logger.LogInformation($"GetFinProgramsFranchisees is fetched");
                IEnumerable<FinProgramsFranchisee> finProgramsFranchisees = _finProgramsFranchiseeService.FetchFinProgramFranchisee(ProgramId).Result;
                return new APIResponse((int)HttpStatusCode.OK, "Franchisee list", finProgramsFranchisees);
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"GetFinProgramsFranchisees has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "Franchisee list", null, apiError);

            }

        }
        [HttpGet]
        [Route("getInvoiceDetails")]
        // [Authorize(Roles = "ReadOnly,ReadWrite,FullAccess")]
        [Authorize (Roles =ApiConstant.Read)]
        //[Authorize(Policy = "ReadOnly")]
        public APIResponse GetInvoiceDetails(int programId, string masterId)
        {
            try
            {
                _logger.LogInformation($"GetInvoiceDetails is fetched");
                IEnumerable<InvoiceDetails> invoiceDetails = _invoiceDetailsService.FetchInvoiceDetails(programId, masterId).Result;
                return new APIResponse((int)HttpStatusCode.OK, "Invoice List", invoiceDetails);
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"GetInvoiceDetails has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "Invoice list", null, apiError);
            }
        }
        [HttpGet]
        [Route("getStatementDetails")]
        //[Authorize(Roles = "ReadOnly,ReadWrite,FullAccess")]
        [Authorize(Roles =ApiConstant.Read)]
        //[Authorize(Policy = "ReadOnly")]
        public APIResponse GetStatementDetails(int programId, string masterId)
        {
            try
            {
                _logger.LogInformation($"GetStatementDetails is fetched");
                IEnumerable<StatementDetails> statementDetails = _StatementDetailsService.FetchStatementDetails(programId, masterId).Result;
                return new APIResponse((int)HttpStatusCode.OK, "Statement List", statementDetails);
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError($"GetStatementDetails has error : " + apiError.ExceptionMessage);
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "Statement List", null, apiError);
            }
        }

    }
}
