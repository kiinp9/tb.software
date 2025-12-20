using Microsoft.AspNetCore.Http;
using traobang.be.domain.TraoBang;

namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class ImportExcelSlideDto
    {
        required public int IdPlan { get; set; }
        required public IFormFile File { get; set; }
    }

    public class ImportExcelMapSlideSinhVienDto
    {
        public domain.TraoBang.Slide Slide { get; set; }
        public DanhSachSinhVienNhanBang? SinhVien { get; set; }
    }
}
