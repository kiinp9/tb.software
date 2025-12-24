using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using traobang.be.application.Base;
using traobang.be.application.TraoBang.Dtos.GiaoDien;
using traobang.be.application.TraoBang.Interfaces;
using traobang.be.domain.TraoBang;
using traobang.be.infrastructure.data;
using traobang.be.shared.Constants.TraoBang;
using traobang.be.shared.HttpRequest.AppException;
using traobang.be.shared.HttpRequest.BaseRequest;
using traobang.be.shared.HttpRequest.Error;

namespace traobang.be.application.TraoBang.Implements
{
    public class GiaoDienService : BaseService, IGiaoDienService
    {
        private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById(
            "SE Asia Standard Time"
        );

        public GiaoDienService(
            TbDbContext tbDbContext,
            ILogger<GiaoDienService> logger,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
            : base(tbDbContext, logger, httpContextAccessor, mapper) { }

        public CreateResultDto Create(CreateGiaoDienDto dto)
        {
            _logger.LogInformation($"{nameof(Create)}, dto = {JsonSerializer.Serialize(dto)}");
            var vietNameNow = GetVietnamTime();
            var giaoDien = new GiaoDien
            {
                NoiDung = dto.NoiDung,
                TenGiaoDien = dto.TenGiaoDien,
                MoTa = dto.MoTa,
                CreatedDate = vietNameNow,
                Deleted = false,
                Html = dto.Html,
                Css = dto.Css,
                Js = dto.Js,
            };
            _tbDbContext.GiaoDiens.Add(giaoDien);
            _tbDbContext.SaveChanges();
            return new CreateResultDto { Id = giaoDien.Id };
        }

        public void Delete(int id)
        {
            _logger.LogInformation($"{nameof(Delete)}, id = {id}");
            var vietNameNow = GetVietnamTime();
            var giaoDien = _tbDbContext.GiaoDiens.FirstOrDefault(e => e.Id == id && !e.Deleted);
            if (giaoDien == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorGiaoDienNotFound);
            }
            giaoDien.Deleted = true;
            giaoDien.DeletedDate = vietNameNow;
            _tbDbContext.GiaoDiens.Update(giaoDien);
            _tbDbContext.SaveChanges();
        }

        public BaseResponsePagingDto<ViewGiaoDienDto> FindPaging(FindPagingGiaoDienDto dto)
        {
            _logger.LogInformation($"{nameof(FindPaging)}, dto = {JsonSerializer.Serialize(dto)}");
            var query =
                from e in _tbDbContext.GiaoDiens
                where !e.Deleted
                orderby e.CreatedDate descending
                select e;
            var data = query.Paging(dto).ToList();
            var items = _mapper.Map<List<ViewGiaoDienDto>>(data);
            return new BaseResponsePagingDto<ViewGiaoDienDto>
            {
                Items = items,
                TotalItems = query.Count(),
            };
        }

        public void Update(UpdateGiaoDienDto dto)
        {
            _logger.LogInformation($"{nameof(Update)}, dto = {JsonSerializer.Serialize(dto)}");
            var giaoDien = _tbDbContext.GiaoDiens.FirstOrDefault(e => e.Id == dto.Id && !e.Deleted);
            if (giaoDien == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorGiaoDienNotFound);
            }
            giaoDien.TenGiaoDien = dto.TenGiaoDien;
            giaoDien.NoiDung = dto.NoiDung;
            giaoDien.MoTa = dto.MoTa;
            giaoDien.Html = dto.Html;
            giaoDien.Css = dto.Css;
            giaoDien.Js = dto.Js;
            _tbDbContext.GiaoDiens.Update(giaoDien);
            _tbDbContext.SaveChanges();
        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, VietnamTimeZone);
        }

        public Task<List<ViewGiaoDienDto>> GetListGiaoDien()
        {
            _logger.LogInformation($"{nameof(GetListGiaoDien)}");
            var giaoDiens = _tbDbContext
                .GiaoDiens.AsNoTracking()
                .Where(e => !e.Deleted)
                .OrderByDescending(e => e.CreatedDate)
                .Select(e => new ViewGiaoDienDto
                {
                    Id = e.Id,
                    TenGiaoDien = e.TenGiaoDien,
                    NoiDung = e.NoiDung,
                    MoTa = e.MoTa,
                    CreatedDate = e.CreatedDate,
                })
                .ToListAsync();
            return giaoDiens;
        }

        public ViewGiaoDienDto FindById(int id)
        {
            _logger.LogInformation($"{nameof(FindById)}, id = {JsonSerializer.Serialize(id)}");
            var giaoDien = _tbDbContext.GiaoDiens.AsNoTracking().FirstOrDefault(e => e.Id == id && !e.Deleted);
            if (giaoDien == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorGiaoDienNotFound);
            }
            return new ViewGiaoDienDto
            {
                Id = giaoDien.Id,
                TenGiaoDien = giaoDien.TenGiaoDien,
                NoiDung = giaoDien.NoiDung,
                MoTa = giaoDien.MoTa,
                CreatedDate = giaoDien.CreatedDate,
                Html = giaoDien.Html,
                Css = giaoDien.Css,
                Js = giaoDien.Js,
            };
        }

        public ViewGiaoDienDto FindByActivePlan()
        {
            _logger.LogInformation($"{nameof(FindByActivePlan)}");

            var plan = _tbDbContext.Plans.AsNoTracking().FirstOrDefault(x => x.TrangThai == TrangThaiPlan.DangHoatDong && !x.Deleted);
            var giaoDien = plan?.GiaoDien;

            return _mapper.Map<ViewGiaoDienDto>(giaoDien);
        }
    }
}
