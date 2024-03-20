using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RSCS.FinancingStatements.API.Controllers
{
    [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private readonly ILogger<WindowsController> _logger;

        public WindowsController(ILogger<WindowsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Info()
        {
            _logger.LogInformation($"Windows Controller Info Method Invoked.");
            return "windows authenticated api";
        }
    }
}
