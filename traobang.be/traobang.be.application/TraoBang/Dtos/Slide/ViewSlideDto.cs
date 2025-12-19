namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class ViewSlideDto
    {
        public int Id { get; set; }
        public int IdSubPlan { get; set; }
        public int LoaiSlide { get; set; }
        public int? IdSinhVienNhanBang { get; set; }
        public string? NoiDung { get; set; }
        public string? Note { get; set; }
        public int TrangThai { get; set; }
        public int Order { get; set; }
        public bool IsShow { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ViewSinhVienNhanBangDto SinhVien { get; set; }
    }
}
