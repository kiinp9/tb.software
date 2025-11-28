using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traobang.be.application.Auth.Dtos.Role;
using traobang.be.application.Auth.Dtos.User;

using traobang.be.application.TraoBang.Dtos;
using traobang.be.domain.Auth;

using traobang.be.domain.TraoBang;

namespace traobang.be.application.Base
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<AppUser, ViewUserDto>();
            CreateMap<AppUser, ViewMeDto>();
            CreateMap<IdentityRole, ViewRoleDto>();

            CreateMap<Plan,ViewPlanDto>();
            CreateMap<SubPlan,ViewSubPlanDto>();
            CreateMap<DanhSachSinhVienNhanBang, ViewSinhVienNhanBangDto>();

        }
    }
}
