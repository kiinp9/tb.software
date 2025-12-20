using Microsoft.AspNetCore.Http;

namespace traobang.be.application.TraoBang.Dtos.SubPlan
{
    public class ImportExcelSubPlanDto
    {
        public int IdPlan { get; set; }
        required public IFormFile File { get; set; }
    }
}
