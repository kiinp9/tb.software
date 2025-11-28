using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traobang.be.application.Auth.Dtos.User;
using traobang.be.domain.Auth;
using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.Auth.Interfaces
{
    public interface IUsersService
    {
        public Task<ViewUserDto> Create(CreateUserDto dto);
        public Task Update(UpdateUserDto dto);
        public Task<BaseResponsePagingDto<ViewUserDto>> FindPaging(FindPagingUserDto dto);
        public Task<ViewUserDto> FindById(string id);
        //public Task<ViewUserDto> FindByMsAccount(string msAccount);
        public Task SetRoleForUser(SetRoleForUserDto dto);
        public Task<ViewMeDto> GetMe();
    }
}
