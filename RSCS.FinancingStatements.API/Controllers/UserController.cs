using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.User;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using RSCS.FinancingStatements.Shared.ResponseHandler;
using System.Net;

namespace RSCS.FinancingStatements.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpGet]
        [Route("user-by-username")]
        public APIResponse FetchUserByUsername(string username)
        {
            try
            {
                _logger.LogInformation($"FetchUserByUsername {username}");

                User user = _userService.FetchUserByUsername(username);
                return new APIResponse((int)HttpStatusCode.OK, "User Details", user);
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError(new Exception($"{ex.Message}"), "error Generated");
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "User Details", null, apiError);
            }
        }

        [HttpPost]
        [Route("create-user")]
        public APIResponse PostUser(User user)
        {
            try
            {
                _logger.LogInformation($"PostUser {user}");
                User users = _userService.CreateUser(user);
                return new APIResponse((int)HttpStatusCode.OK, "Create User ", users);
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError(ex.Message);
                _logger.LogError(new Exception($"{ex.Message}"), "Error in creating User");
                return new APIResponse((int)HttpStatusCode.ExpectationFailed, "create User ", null, apiError);
            }
        }
    }
}
