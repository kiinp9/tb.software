using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Dtos
{
    public class FindPagingSubPlanDto : BaseRequestPagingDto
    {
        public int? IdPlan { get; set; }
    }
}
