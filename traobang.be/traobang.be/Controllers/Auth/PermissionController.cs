using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using traobang.be.application.Auth.Interfaces;
using traobang.be.Attributes;
using traobang.be.Controllers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using traobang.be.shared.Constants.Auth;
using traobang.be.shared.HttpRequest;

namespace traobang.be.Controllers.Auth
{
    [Route("api/app/permissions")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PermissionController : BaseController
    {
        private readonly IPermissionsService _permissionsService;
        public PermissionController(ILogger<BaseController> logger, IPermissionsService permissionsService) : base(logger)
        {
            _permissionsService = permissionsService;
        }

        /// <summary>
        /// Lấy toàn bộ permission
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [Permission(PermissionKeys.RoleView)]
        public ApiResponse GetAll()
        {
            try
            {
                var data = _permissionsService.GetAllPermissions();
                return new(data);
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
