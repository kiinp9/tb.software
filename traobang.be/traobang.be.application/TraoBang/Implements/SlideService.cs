using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using traobang.be.application.Base;
using traobang.be.application.TraoBang.Dtos;
using traobang.be.application.TraoBang.Dtos.Slide;
using traobang.be.application.TraoBang.Interfaces;
using traobang.be.domain.TraoBang;
using traobang.be.infrastructure.data;
using traobang.be.shared.Constants.TraoBang;
using traobang.be.shared.HttpRequest.AppException;
using traobang.be.shared.HttpRequest.BaseRequest;
using traobang.be.shared.HttpRequest.Error;

namespace traobang.be.application.TraoBang.Implements
{
    public class SlideService : BaseService, ISlideService
    {
        public SlideService(
            TbDbContext tbDbContext,
            ILogger<SlideService> logger,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        : base(tbDbContext, logger, httpContextAccessor, mapper)
        {
        }

        public void Create(CreateSlideDto dto)
        {
            _logger.LogInformation($"{nameof(Create)}, dto = {JsonSerializer.Serialize(dto)}");
            var username = getCurrentName();
            if (dto.LoaiSlide == LoaiSlides.BINH_THUONG && string.IsNullOrEmpty(dto.NoiDung))
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorLoaiSlideBinhThuongPhaiCoNoiDung);
            }

            if (dto.LoaiSlide == LoaiSlides.SINH_VIEN && dto.SinhVien == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorLoaiSlideSinhVienPhaiCoSinhVien);
            }

            int? idSv = null;
            if (dto.LoaiSlide == LoaiSlides.SINH_VIEN && !string.IsNullOrEmpty(dto.SinhVien?.MaSoSinhVien))
            {
                var inputSv = _mapper.Map<DanhSachSinhVienNhanBang>(dto.SinhVien);
                inputSv.CreatedBy = username;
                _tbDbContext.DanhSachSinhVienNhanBangs.Add(inputSv);

                _tbDbContext.SaveChanges();
                idSv = inputSv.Id;
            }

            var qr = _tbDbContext.Slides.AsNoTracking().Where(x => x.IdSubPlan == dto.IdSubPlan && !x.Deleted);
            int maxSlideOrder = qr.Any() ? qr.Max(x => x.Order) : 0;

            _tbDbContext.Slides.Add(new Slide()
            {
                IdSinhVienNhanBang = idSv,
                IdSubPlan = dto.IdSubPlan,
                IsShow = dto.IsShow,
                NoiDung = dto.NoiDung,
                LoaiSlide = dto.LoaiSlide,
                Note = dto.Note,
                TrangThai = dto.TrangThai,
                Order = maxSlideOrder + 1,
                CreatedBy = username
            });
            _tbDbContext.SaveChanges();
        }

        public void Update(UpdateSlideDto dto)
        {
            _logger.LogInformation($"{nameof(Create)}, dto = {JsonSerializer.Serialize(dto)}");

            if (dto.LoaiSlide == LoaiSlides.BINH_THUONG && string.IsNullOrEmpty(dto.NoiDung))
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorLoaiSlideBinhThuongPhaiCoNoiDung);
            }

            if (dto.LoaiSlide == LoaiSlides.SINH_VIEN && dto.SinhVien == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorLoaiSlideSinhVienPhaiCoSinhVien);
            }

            var slide = _tbDbContext.Slides.FirstOrDefault(x => x.Id == dto.Id && !x.Deleted);
            if (slide == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorSlideNotFound);
            }

            slide.IdSubPlan = dto.IdSubPlan;
            slide.IsShow = dto.IsShow;
            slide.NoiDung = dto.NoiDung;
            slide.LoaiSlide = dto.LoaiSlide;
            slide.Note = dto.Note;
            slide.TrangThai = dto.TrangThai;
            slide.Order = dto.Order;

            if (dto.SinhVien != null)
            {
                var sv = _tbDbContext.DanhSachSinhVienNhanBangs.FirstOrDefault(x => x.Id == dto.SinhVien.Id && !x.Deleted);
                if (sv != null)
                {
                    sv.HoVaTen = dto.SinhVien.HoVaTen;
                    sv.MaSoSinhVien = dto.SinhVien.MaSoSinhVien;
                    sv.Lop = dto.SinhVien.Lop;
                    sv.NgaySinh = dto.SinhVien.NgaySinh;
                    sv.CapBang = dto.SinhVien.CapBang;
                    sv.TenNganhDaoTao = dto.SinhVien.TenNganhDaoTao;
                    sv.XepHang = dto.SinhVien.XepHang;
                    sv.ThanhTich = dto.SinhVien.ThanhTich;
                    sv.Email = dto.SinhVien.Email;
                    sv.EmailSinhVien = $"{dto.SinhVien.MaSoSinhVien}@st.huce.edu.vn";
                    sv.KhoaQuanLy = dto.SinhVien.KhoaQuanLy;
                    sv.SoQuyetDinhTotNghiep = dto.SinhVien.SoQuyetDinhTotNghiep;
                    sv.NgayQuyetDinh = dto.SinhVien.NgayQuyetDinh;
                    sv.Note = dto.SinhVien.Note;
                    sv.LinkQR = dto.SinhVien.LinkQR;
                }
            }

            _tbDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogInformation($"{nameof(Create)}, id = {id}");

            var slide = _tbDbContext.Slides.FirstOrDefault(x => x.Id == id && !x.Deleted);
            if (slide == null)
            {
                throw new UserFriendlyException(ErrorCodes.TraoBangErrorSlideNotFound);
            }

            var username = getCurrentName();

            slide.Deleted = true;
            slide.DeletedDate = DateTime.Now;
            slide.DeletedBy = username;

            _tbDbContext.SaveChanges();
        }

        public BaseResponsePagingDto<ViewSlideDto> FindPaging(FindPagingSlideDto dto)
        {
            _logger.LogInformation($"{nameof(FindPagingSlideDto)}, dto = {JsonSerializer.Serialize(dto)}");

            var query = from s in _tbDbContext.Slides.AsNoTracking().Where(x => !x.Deleted)
                        from sv in _tbDbContext.DanhSachSinhVienNhanBangs.AsNoTracking().Where(x => x.Id == s.IdSinhVienNhanBang && !x.Deleted).DefaultIfEmpty()
                        where string.IsNullOrEmpty(dto.Keyword) || (
                            (s.NoiDung ?? "").Trim().ToLower().Contains(dto.Keyword.Trim().ToLower()) ||
                            (sv.HoVaTen ?? "").Trim().ToLower().Contains(dto.Keyword.Trim().ToLower())
                        )
                        orderby s.Order
                        select new ViewSlideDto()
                        {
                            Id = s.Id,
                            IdSubPlan = s.IdSubPlan,
                            IdSinhVienNhanBang = s.IdSinhVienNhanBang,
                            LoaiSlide = s.LoaiSlide,
                            IsShow = s.IsShow,
                            CreatedBy = s.CreatedBy,
                            CreatedDate = s.CreatedDate,
                            NoiDung = s.NoiDung,
                            Note = s.Note,
                            Order = s.Order,
                            TrangThai = s.TrangThai,
                            SinhVien = new Dtos.ViewSinhVienNhanBangDto()
                            {
                                Id = sv.Id,
                                Note = sv.Note,
                                SoQuyetDinhTotNghiep = sv.SoQuyetDinhTotNghiep,
                                CapBang = sv.CapBang,
                                Email = sv.Email,
                                EmailSinhVien = sv.EmailSinhVien,
                                HoVaTen = sv.HoVaTen,
                                KhoaQuanLy = sv.KhoaQuanLy,
                                LinkQR = sv.LinkQR,
                                Lop = sv.Lop,
                                MaSoSinhVien = sv.MaSoSinhVien,
                                NgayQuyetDinh = sv.NgayQuyetDinh,
                                NgaySinh = sv.NgaySinh,
                                TenNganhDaoTao = sv.TenNganhDaoTao,
                                ThanhTich = sv.ThanhTich,
                                XepHang = sv.XepHang,
                            }
                        };
            var items = query.Paging(dto).ToList();
            return new BaseResponsePagingDto<ViewSlideDto>
            {
                TotalItems = query.Count(),
                Items = items
            };
        }

        public ViewSlideDto FindById(int id)
        {
            _logger.LogInformation($"{nameof(Create)}, id = {id}");

            var slide = _tbDbContext.Slides.FirstOrDefault(x => x.Id == id && !x.Deleted);
            var data = _mapper.Map<ViewSlideDto>(slide);

            var sv = _tbDbContext.DanhSachSinhVienNhanBangs.FirstOrDefault(x => x.Id == slide.IdSinhVienNhanBang && !x.Deleted);
            data.SinhVien = _mapper.Map<ViewSinhVienNhanBangDto>(sv);
            return data;
        }
    }
}
