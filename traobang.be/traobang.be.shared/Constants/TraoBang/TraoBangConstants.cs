namespace traobang.be.shared.Constants.TraoBang
{
    public static class TraoBangConstants
    {
        /// <summary>
        /// trong hàng đợi
        /// </summary>
        public const int XepHang = 1;
        /// <summary>
        /// chuẩn bị lên bục nhận bằng
        /// </summary>
        public const int ChuanBi = 2;
        /// <summary>
        /// đang được trao bằng
        /// </summary>
        public const int DangTraoBang = 3;
        /// <summary>
        /// đã trao bằng rồi
        /// </summary>
        public const int DaTraoBang = 4;
        /// <summary>
        /// sẽ tham gia trao bằng (ko dùng trong bảng tiến độ)
        /// </summary>
        public const int ThamGiaTraoBang = 5;
        /// <summary>
        /// ko đi nhận bằng (ko dùng trong bảng tiến độ)
        /// </summary>
        public const int VangMat = 6;
    }

    public static class TrangThaiSubPlan
    {
        public const int XepHang = 1;
        public const int ChuanBi = 2;
        public const int DangTraoBang = 3;
        public const int DaTraoBang = 4;
        public const int ThamGiaTraoBang = 5;
        public const int VangMat = 6;
    }

    public static class ViewSvTypeConstants
    {
        public const int SV = 1;
        public const int MO_BAI = 2;
        public const int KET_BAI = 3;
    }

    public static class LoaiSlides
    {
        public const int TEXT = 1;
        public const int SINH_VIEN = 2;
    }

    public static class TrangThaiPlan
    {
        public const int KhoiTao = 1;
        public const int DangHoatDong = 2;
        public const int DaKetThuc = 3;
    }
}
