using traobang.be.application.TraoBang.Dtos.Slide;
using traobang.be.shared.HttpRequest.BaseRequest;

namespace traobang.be.application.TraoBang.Interfaces
{
    public interface ISlideService
    {
        /// <summary>
        /// Tạo slide
        /// </summary>
        /// <param name="dto"></param>
        public void Create(CreateSlideDto dto);
        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="dto"></param>
        public void Update(UpdateSlideDto dto);
        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
        /// <summary>
        /// Tìm kiếm slide phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseResponsePagingDto<ViewSlideDto> FindPaging(FindPagingSlideDto dto);
        /// <summary>
        /// Tìm theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewSlideDto FindById(int id);
        /// <summary>
        /// Tải mẫu excel để import slide
        /// </summary>
        /// <returns></returns>
        public byte[] DownloadTemplateImport();
        /// <summary>
        /// Import slide từ excel
        /// </summary>
        /// <param name="dto"></param>
        public void ImportSlide(ImportExcelSlideDto dto);
        /// <summary>
        /// Generate QR cho sv nhận bằng theo plan
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task GenerateQr(GenerateSinhVienQrDto dto);
        /// <summary>
        /// Generate qr cho 1 sv nhận bằng
        /// </summary>
        /// <param name="idSlide"></param>
        /// <returns></returns>
        public Task GenerateQrOneSv(int idSlide);
        /// <summary>
        /// Thêm nhanh slide vào hàng đợi slide ở màn checkin
        /// </summary>
        /// <param name="dto"></param>
        public void CreateSlideTextFast(CreateSlideTextFastDto dto);
        /// <summary>
        /// Kéo thả slide trong hàng đợi ở màn checkin
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateTienDoOrder(UpdateTienDoOrderDto dto);
    }
}
