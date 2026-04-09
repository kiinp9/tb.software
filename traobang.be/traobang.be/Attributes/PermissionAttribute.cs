using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using traobang.be.infrastructure.data;
using traobang.be.shared.Constants.Auth;

namespace traobang.be.Attributes
{
    public class PermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string[] Permissions { get; }
        public PermissionAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity!.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var username = user.FindFirstValue("username");

            var dbContext = context.HttpContext
                .RequestServices
                .GetService(typeof(TbDbContext)) as TbDbContext;

            if (dbContext != null)
            {
                // check role super admin
                var isSuperAdmin = (
                                    from u in dbContext.Users
                                    join userRole in dbContext.UserRoles on u.Id equals userRole.UserId
                                    join role in dbContext.Roles on userRole.RoleId equals role.Id
                                    where u.UserName == username
                                      && role.Name == RoleConstants.ROLE_SUPER_ADMIN
                                    select role.Name).Any();
                if (isSuperAdmin)
                {
                    return;
                }

                // check per
                var isPermit = (
                        from u in dbContext.Users
                        join userRole in dbContext.UserRoles on u.Id equals userRole.UserId
                        join role in dbContext.Roles on userRole.RoleId equals role.Id
                        join roleClaims in dbContext.RoleClaims on role.Id equals roleClaims.RoleId
                        where u.UserName == username
                          && roleClaims.ClaimType == CustomClaimTypes.Permission
                          && Permissions.Contains(roleClaims.ClaimValue)
                        select roleClaims.ClaimValue).Any();

                if (isPermit)
                {
                    return;
                }
            }

            //Return based on logic
            context.Result = new ForbidResult();
        }
    }
}
