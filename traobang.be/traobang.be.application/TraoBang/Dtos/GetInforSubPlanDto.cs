using traobang.be.application.TraoBang.Dtos.Slide;

namespace traobang.be.application.TraoBang.Dtos
{
    public class GetInforSubPlanDto
    {
        public string Ten { get; set; } = String.Empty;
        public int SoLuongThamGia { get; set; }
        public int SoLuongVangMat { get; set; }
        public int SoLuongDaTrao { get; set; }
        public int SoLuongConLai { get; set; }
        public List<ViewSlideDto> SlideTexts { get; set; } = new List<ViewSlideDto>();
    }
}
