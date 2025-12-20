using Microsoft.AspNetCore.Http;

namespace traobang.be.infrastructure.external.Excel
{
    public interface IExcelService
    {
        public List<List<string>> ReadExcelFile(IFormFile file, string sheetName);
    }
}
