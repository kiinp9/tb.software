using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traobang.be.infrastructure.external.SignalR.Service.Interfaces
{
    public interface ITraoBangService
    {
       public Task NotifySinhVienDangTrao();
       public Task NotifyChonKhoa();
       //public Task NotifyChuyenKhoa();
       public Task NotifyCheckIn();
     

    }
}
