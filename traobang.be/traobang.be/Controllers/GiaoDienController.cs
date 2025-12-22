using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using traobang.be.application.TraoBang.Interfaces;
using traobang.be.Controllers.Base;

namespace traobang.be.Controllers
{
    [Route("api/core/trao-bang/giao-dien")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GiaoDienController : BaseController
    {
        private readonly IGiaoDienService _giaoDienService;

        public GiaoDienController(
            ILogger<GiaoDienController> logger,
            IGiaoDienService giaoDienService
        )
            : base(logger)
        {
            _giaoDienService = giaoDienService;
        }


    }
}
