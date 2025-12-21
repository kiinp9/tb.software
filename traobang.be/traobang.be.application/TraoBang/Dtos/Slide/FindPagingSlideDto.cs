using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class FindPagingSlideDto : BaseRequestPagingDto
    {
        public int? IdPlan { get; set; }
        public int? IdSubPlan { get; set; }
    }
}
