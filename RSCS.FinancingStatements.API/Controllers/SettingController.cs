using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.Setting;
using RSCS.FinancingStatements.Core.Interfaces.Service;

namespace RSCS.FinancingStatements.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ILogger<SettingController> _logger;
        private readonly ISettingService _settingService;

        public SettingController(ILogger<SettingController> logger, ISettingService settingService)
        {
            _logger = logger;
            _settingService = settingService;
        }

        [HttpGet]
        [Route("some-settings")]
        public IEnumerable<Setting> FetchSomeSettings()
        {
            _logger.LogInformation($"SettingController FetchSomeSettings");
            return _settingService.FetchSystemSettingsAsync().Result;
        }
    }
}
