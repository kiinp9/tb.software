using traobang.be.application.Auth.Dtos.Role;
using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.Auth.Interfaces
{
    public interface IRoleService
    {
        public Task Create(CreateRoleDto dto);
        public Task Update(UpdateRoleDto dto);
        public Task<BaseResponsePagingDto<ViewRoleDto>> FindPaging(FindPagingRoleDto dto);
        public Task<ViewRoleDto> FindById(string id);
        public Task<List<ViewRoleDto>> GetList();
        public Task Delete(string id);
    }
}
