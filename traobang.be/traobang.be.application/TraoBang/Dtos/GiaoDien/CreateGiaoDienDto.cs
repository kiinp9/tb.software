namespace traobang.be.application.TraoBang.Dtos.GiaoDien
{
    public class CreateGiaoDienDto
    {
        private string _tenGiaoDien = string.Empty;
        private string? _html = string.Empty;
        private string? _css = string.Empty;
        private string? _js = string.Empty;
        public required string NoiDung { get; set; }
        public required string TenGiaoDien
        {
            get => _tenGiaoDien;
            set => _tenGiaoDien = value?.Trim() ?? string.Empty;
        }

        private string? _moTa;
        public string? MoTa
        {
            get => _moTa;
            set => _moTa = value?.Trim();
        }

        public string? Html { get => _html; set => _html = value?.Trim(); }
        public string? Css { get => _css; set => _css = value?.Trim(); }
        public string? Js { get => _js; set => _js = value?.Trim(); }
    }
}
