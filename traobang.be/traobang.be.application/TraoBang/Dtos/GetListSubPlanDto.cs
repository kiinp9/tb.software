using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traobang.be.application.TraoBang.Dtos
{
    public class GetListSubPlanDto
    {
        public int Id { get; set; }
        public string Ten { get; set; } = String.Empty;
        public string TienDo { get; set; } = String.Empty;
        public int Order { get; set; }
        public int TrangThai { get; set; }
    }

}
