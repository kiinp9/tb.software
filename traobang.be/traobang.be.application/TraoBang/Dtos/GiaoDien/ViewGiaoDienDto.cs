namespace traobang.be.application.TraoBang.Dtos.GiaoDien
{
    public class ViewGiaoDienDto
    {
        public int Id { get; set; }
        public string? TenGiaoDien { get; set; }
        public string? NoiDung { get; set; }
        public string? MoTa { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Html { get; set; }
        public string? Css { get; set; }
        public string? Js { get; set; }
    }
}
