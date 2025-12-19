using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using traobang.be.application.TraoBang.Dtos.Slide;
using traobang.be.application.TraoBang.Interfaces;
using traobang.be.Controllers.Base;
using traobang.be.shared.HttpRequest;

namespace traobang.be.Controllers.Config
{
    [Route("api/config/slide")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ConfigSlideController : BaseController
    {
        private readonly ISlideService _slideService;
        public ConfigSlideController(ILogger<ConfigSlideController> logger, ISlideService slideService) : base(logger)
        {
            _slideService = slideService;
        }

        /// <summary>
        /// Tạo slide
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public ApiResponse Create(CreateSlideDto dto)
        {
            try
            {
                _slideService.Create(dto);
                return new();
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Cập nhật slide
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("")]
        public ApiResponse Update(UpdateSlideDto dto)
        {
            try
            {
                _slideService.Update(dto);
                return new();
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Xóa slide
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ApiResponse Delete([FromRoute] int id)
        {
            try
            {
                _slideService.Delete(id);
                return new();
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpGet("")]
        public ApiResponse FindPaging([FromQuery] FindPagingSlideDto dto)
        {
            try
            {
                var result = _slideService.FindPaging(dto);
                return new(result);
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpGet("{id}")]
        public ApiResponse FindById([FromRoute] int id)
        {
            try
            {
                var result = _slideService.FindById(id);
                return new(result);
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
