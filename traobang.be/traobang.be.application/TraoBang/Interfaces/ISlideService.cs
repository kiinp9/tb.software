using traobang.be.application.TraoBang.Dtos.Slide;
using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Interfaces
{
    public interface ISlideService
    {
        public void Create(CreateSlideDto dto);
        public void Update(UpdateSlideDto dto);
        public void Delete(int id);
        public BaseResponsePagingDto<ViewSlideDto> FindPaging(FindPagingSlideDto dto);
        public ViewSlideDto FindById(int id);
    }
}
