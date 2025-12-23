using traobang.be.application.TraoBang.Dtos.GiaoDien;
using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Interfaces
{
    public interface IGiaoDienService
    {
        public CreateResultDto Create(CreateGiaoDienDto dto);
        public void Update(UpdateGiaoDienDto dto);
        public ViewGiaoDienDto FindById(int id);
        public BaseResponsePagingDto<ViewGiaoDienDto> FindPaging(FindPagingGiaoDienDto dto);
        public Task<List<ViewGiaoDienDto>> GetListGiaoDien();
        public void Delete(int id);
    }
}
