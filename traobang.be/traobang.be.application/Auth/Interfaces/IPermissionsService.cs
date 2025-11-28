using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using traobang.be.application.Auth.Dtos.Permission;

namespace traobang.be.application.Auth.Interfaces
{
    public interface IPermissionsService
    {
        /// <summary>
        /// Lấy danh sách quyền
        /// </summary>
        /// <returns></returns>
        public List<ViewPermissionDto> GetAllPermissions();
    }
}
