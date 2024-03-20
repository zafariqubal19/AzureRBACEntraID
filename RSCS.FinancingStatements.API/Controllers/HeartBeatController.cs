using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.HeartbeatModel;
using Swashbuckle.AspNetCore.Annotations;

namespace RSCS.FinancingStatements.API.Controllers
{
    [Route("api/Health")]
    [ApiController]
    public class HeartBeatController : ControllerBase
    {
        private readonly ILogger<HeartBeatController> _logger;

        public HeartBeatController(ILogger<HeartBeatController> logger)
        {
            _logger = logger;
        }

        [HttpGet("heartbeat")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns application heartbeat status.", typeof(HeartbeatModel))]
        public IActionResult Heartbeat()
        {
            _logger.LogInformation($"Heartbeat is fetched");
            return Ok(new HeartbeatModel());
        }


    }
}
