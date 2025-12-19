namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class CreateSlideSinhVienDto
    {
        public string HoVaTen { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string EmailSinhVien { get; set; } = String.Empty;
        public string MaSoSinhVien { get; set; } = String.Empty;
        public string Lop { get; set; } = String.Empty;
        public DateTime NgaySinh { get; set; }
        public string CapBang { get; set; } = String.Empty;
        public string TenNganhDaoTao { get; set; } = String.Empty;
        public string XepHang { get; set; } = String.Empty;
        public string ThanhTich { get; set; } = String.Empty;
        public string KhoaQuanLy { get; set; } = String.Empty;
        public string SoQuyetDinhTotNghiep { get; set; } = String.Empty;
        public DateTime NgayQuyetDinh { get; set; }
        public string? Note { get; set; }
        public string LinkQR { get; set; } = String.Empty;
    }
}
