namespace traobang.be.application.TraoBang.Dtos.GiaoDien
{
    public class CreateGiaoDienDto
    {
        private string _tenGiaoDien = string.Empty;
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
    }
}
