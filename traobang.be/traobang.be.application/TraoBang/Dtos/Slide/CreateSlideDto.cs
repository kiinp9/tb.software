using traobang.be.shared.Constants.TraoBang;

namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class CreateSlideDto
    {
        private string? _noiDung;

        public int IdSubPlan { get; set; }
        /// <summary>
        /// <see cref="LoaiSlides"/>
        /// </summary>
        public int LoaiSlide { get; set; }
        public int IdSinhVienNhanBang { get; set; }
        public string? NoiDung { get => _noiDung; set => _noiDung = value?.Trim(); }
        public string? Note { get; set; }
        /// <summary>
        /// <see cref="TraoBangConstants"/>
        /// </summary>
        public int TrangThai { get; set; }
        public bool IsShow { get; set; }
        public CreateSlideSinhVienDto SinhVien { get; set; } = new CreateSlideSinhVienDto();
    }
}
