using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Dtos
{
    public class FindPagingSinhVienNhanBangDto : BaseRequestPagingDto
    {
        public int IdSubPlan { get; set; }
    }
}
