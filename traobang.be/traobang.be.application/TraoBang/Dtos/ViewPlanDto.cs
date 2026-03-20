namespace traobang.be.application.TraoBang.Dtos
{
    public class ViewPlanDto
    {
        public int Id { get; set; }
        public string Ten { get; set; } = String.Empty;
        public string MoTa { get; set; } = String.Empty;
        public int TrangThai { get; set; }
        public int? IdGiaoDien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
