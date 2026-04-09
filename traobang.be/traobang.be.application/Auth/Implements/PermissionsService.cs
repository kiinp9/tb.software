using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using traobang.be.application.Auth.Dtos.Permission;
using traobang.be.application.Auth.Interfaces;
using traobang.be.application.Base;
using traobang.be.infrastructure.data;
using traobang.be.shared.Constants.Auth;

namespace traobang.be.application.Auth.Implements
{
    public class PermissionsService : BaseService, IPermissionsService
    {
        public PermissionsService(
            TbDbContext tbDbContext, ILogger<BaseService> logger, IHttpContextAccessor httpContextAccessor, IMapper mapper
        ) : base(tbDbContext, logger, httpContextAccessor, mapper)
        {
        }

        public List<ViewPermissionDto> GetAllPermissions()
        {
            _logger.LogInformation($"{nameof(GetAllPermissions)}");

            var query = PermissionKeys.All.Select(x => new ViewPermissionDto
            {
                Key = x.Key,
                Name = x.Name,
                Category = x.Category
            }).ToList();

            return query;
        }
    }
}
