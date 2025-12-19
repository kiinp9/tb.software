namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class UpdateSlideDto
    {
        private string? _noiDung;

        public int Id { get; set; }
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
        public int Order { get; set; }
        public UpdateSlideSinhVienDto SinhVien { get; set; } = new UpdateSlideSinhVienDto();
    }
}
