using traobang.be.application.TraoBang.Dtos;
using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Interface
{
    public interface IPlanService
    {
        public void Create(CreatePlanDto dto);
        public void Update(int id, UpdatePlanDto dto);
        public BaseResponsePagingDto<ViewPlanDto> FindPaging(FindPagingPlanDto dto);
        public void Delete(int id);
        public Task<List<GetListPlanResponseDto>> GetListPlan();
        public void DeleteConfig(int id);
    }
}
