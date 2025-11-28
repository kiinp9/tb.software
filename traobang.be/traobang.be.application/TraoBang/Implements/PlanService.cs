using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using traobang.be.application.Base;
using traobang.be.application.TraoBang.Dtos;
using traobang.be.application.TraoBang.Interface;
using traobang.be.infrastructure.data;
using traobang.be.shared.HttpRequest.AppException;
using traobang.be.shared.HttpRequest.BaseRequest;
using traobang.be.shared.HttpRequest.Error;


namespace traobang.be.application.TraoBang.Implements
{
    public class PlanService: BaseService,IPlanService
    {
        private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        public PlanService(
            TbDbContext tbDbContext,
            ILogger<PlanService> logger,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
            : base(tbDbContext, logger, httpContextAccessor, mapper)
        {
        }
        public void Create(CreatePlanDto dto)
        {
            _logger.LogInformation($"{nameof(Create)}, dto = {JsonSerializer.Serialize(dto)}");
            var vietnameNow = GetVietnamTime();
            var plan = new domain.TraoBang.Plan
            {
                Ten = dto.Ten,
                MoTa = dto.MoTa,
                ThoiGianBatDau = dto.ThoiGianBatDau,
                ThoiGianKetThuc = dto.ThoiGianKetThuc,
                CreatedDate = vietnameNow,
                Deleted = false
            };
            _tbDbContext.Plans.Add(plan);
            _tbDbContext.SaveChanges();


        }
        public void Update(int id, UpdatePlanDto dto)
        {
            _logger.LogInformation($"{nameof(Update)}, dto = {JsonSerializer.Serialize(dto)}");
            var plan = _tbDbContext.Plans.FirstOrDefault(x => x.Id == id && !x.Deleted);
            if (plan == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorPlanNotFound);
            }
            var vietnameNow = GetVietnamTime();
            plan.Ten = dto.Ten;
            plan.MoTa = dto.MoTa;
            plan.ThoiGianBatDau = dto.ThoiGianBatDau;
            plan.ThoiGianKetThuc = dto.ThoiGianKetThuc;
            _tbDbContext.Plans.Update(plan);
            _tbDbContext.SaveChanges();
        }
        public BaseResponsePagingDto<ViewPlanDto> FindPaging( FindPagingPlanDto dto)
        {
            _logger.LogInformation($"{nameof(FindPaging)}, dto = {JsonSerializer.Serialize(dto)}");
            var query = from p in _tbDbContext.Plans
                        where !p.Deleted
                        orderby p.CreatedDate descending
                        select p;
            var data = query.Paging(dto).ToList();
            var items = _mapper.Map<List<ViewPlanDto>>(data);
            return new BaseResponsePagingDto<ViewPlanDto>
            {
                TotalItems = query.Count(),
                Items = items
            };  
        }
        public async Task<List<GetListPlanResponseDto>> GetListPlan()
        {
            _logger.LogInformation($"{nameof(GetListPlan)}");

            var plans = await _tbDbContext.Plans
                .AsNoTracking()
                .Where(x => !x.Deleted)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new GetListPlanResponseDto
                {
                    Id = x.Id,
                    Ten = x.Ten
                })
                .ToListAsync();

            return plans;
        }
        public void Delete(int id)
        {
            _logger.LogInformation($"{nameof(Delete)}, id = {id}");
            var vietnameNow = GetVietnamTime();
            var plan = _tbDbContext.Plans.FirstOrDefault(x => x.Id == id && !x.Deleted);
            if (plan == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorPlanNotFound);
            }
            plan.DeletedDate = vietnameNow;
            plan.Deleted = true;
            _tbDbContext.Plans.Update(plan);
            _tbDbContext.SaveChanges();
        }   
        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, VietnamTimeZone);
        }
    }
}
