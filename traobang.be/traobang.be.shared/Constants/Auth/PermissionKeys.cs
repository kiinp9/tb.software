namespace traobang.be.shared.Constants.Auth
{
    public static class PermissionKeys
    {
        public const string Menu = "Menu.";
        public const string Function = "Function.";

        #region menu màn hình
        public const string MenuManHinh = Menu + "ManHinh";
        public const string MenuManHinhSanKhau = MenuManHinh + "_SanKhau";
        public const string MenuManHinhCanhGa = MenuManHinh + "_CanhGa";
        public const string MenuManHinhDieuKhien = MenuManHinh + "_DieuKhien";
        public const string MenuManHinhCheckin = MenuManHinh + "_Checkin";
        #endregion

        #region menu cấu hình
        public const string MenuCauHinh = Menu + "_CauHinh";
        public const string MenuCauHinhChuongTrinh = MenuCauHinh + "_ChuongTrinh";
        public const string MenuCauHinhKhoa = MenuCauHinh + "_Khoa";
        public const string MenuCauHinhSlide = MenuCauHinh + "_Slide";
        public const string MenuCauHinhGiaoDien = MenuCauHinh + "_GiaoDien";
        #endregion cấu hình

        #region menu user
        public const string MenuUserManagement = Menu + "UserManagement";
        public const string MenuUserManagementUser = MenuUserManagement + "_User";
        public const string MenuUserManagementRole = MenuUserManagement + "_User";
        #endregion

        #region chức năng trong menu user
        public const string CategoryUser = "QL User";
        public const string UserAdd = Function + "UserAdd";
        public const string UserUpdate = Function + "UserUpdate";
        public const string UserDelete = Function + "UserDelete";
        public const string UserView = Function + "UserView";
        public const string UserSetRoles = Function + "UserSetRoles";
        #endregion

        #region chức năng trong menu role
        public const string CategoryRole = "QL Role";
        public const string RoleAdd = Function + "Add";
        public const string RoleUpdate = Function + "Update";
        public const string RoleDelete = Function + "Delete";
        public const string RoleView = Function + "View";
        #endregion

        #region chức năng trong menu cấu hình plan
        public const string CategoryCauHinhPlan = "QL Plan";
        public const string PlanAdd = Function + "PlanAdd";
        public const string PlanUpdate = Function + "PlanUpdate";
        public const string PlanDelete = Function + "PlanDelete";
        public const string PlanView = Function + "PlanView";
        #endregion

        #region chức năng trong menu cấu hình subplan / khoa
        public const string CategoryCauHinhSubPlan = "QL SubPlan";
        public const string SubPlanAdd = Function + "SubPlanAdd";
        public const string SubPlanUpdate = Function + "SubPlanUpdate";
        public const string SubPlanDelete = Function + "SubPlanDelete";
        public const string SubPlanView = Function + "SubPlanView";
        #endregion

        #region chức năng trong menu cấu hình giao diện
        public const string CategoryCauHinhGiaoDien = "QL GiaoDien";
        public const string GiaoDiennAdd = Function + "GiaoDienAdd";
        public const string GiaoDienUpdate = Function + "GiaoDienUpdate";
        public const string GiaoDienDelete = Function + "GiaoDienDelete";
        public const string GiaoDienView = Function + "GiaoDienView";
        #endregion

        #region chức năng trong menu cấu hình slide
        public const string CategoryCauHinhSlide = "QL Slide";
        public const string SlideAdd = Function + "SlideAdd";
        public const string SlideUpdate = Function + "SlideUpdate";
        public const string SlideDelete = Function + "SlideDelete";
        public const string SlideView = Function + "SlideView";
        #endregion

        #region chức năng trong màn checkin, san khau, canh ga, dieu khien
        public const string CategoryMainFunction = "Chức năng chính";
        public const string SlideTextAddFast = Function + "SlideTextAddFast";
        public const string SlideUpdateOrderTienDo = Function + "SlideUpdateOrderTienDo";
        public const string SlideRevertTienDo = Function + "SlideRevertTienDo";

        public const string DieuKhienView = Function + "DieuKhienView";
        public const string CheckinView = Function + "CheckinView";

        public const string PushSinhVienVaoHangDoi = Function + "PushSinhVienVaoHangDoi";
        public const string GetTienDo = Function + "GetTienDo";
        public const string NextSubPlan = Function + "NextSubPlan";
        public const string GetSubPlansOfActivePlan = Function + "GetSubPlansOfActivePlan";
        public const string UpdateTrangThaiSv = Function + "UpdateTrangThaiSv";
        public const string GetSvChuanBiNhanBang = Function + "GetSvChuanBiNhanBang";
        public const string PushSlideVaoHangDoi = Function + "PushSlideVaoHangDoi";
        public const string RestartActivePlan = Function + "RestartActivePlan";
        public const string DemoMode = Function + "DemoMode";
        #endregion

        public static readonly (string Key, string Name, string Category)[] All =
        {

            (MenuUserManagement, "Menu Quản lý User", "Menu"),
            (MenuUserManagementUser, "[Menu Quản lý User] User", "Menu"),
            (MenuUserManagementRole, "[Menu Quản lý User] Role", "Menu"),

            (MenuCauHinh, "Menu Cấu hình", "Menu"),
            (MenuCauHinhChuongTrinh, "[Menu Cấu hình] Chương trình", "Menu"),
            (MenuCauHinhKhoa, "[Menu Cấu hình] Khoa", "Menu"),
            (MenuCauHinhSlide, "[Menu Cấu hình] Slide", "Menu"),
            (MenuCauHinhGiaoDien, "[Menu Cấu hình] Giao diện", "Menu"),

            (MenuManHinh, "Menu Màn hình", "Menu"),
            (MenuManHinhDieuKhien, "[Menu Màn hình] Điều khiển ", "Menu"),
            (MenuManHinhSanKhau, "[Menu Màn hình] Sân khấu ", "Menu"),
            (MenuManHinhCheckin, "[Menu Màn hình] Checkin ", "Menu"),
            (MenuManHinhCanhGa, "[Menu Màn hình] Cánh gà ", "Menu"),

            (UserAdd, "[Cấu hình User] Thêm", CategoryUser),
            (UserUpdate, "[Cấu hình User] Cập nhật" , CategoryUser),
            (UserDelete, "[Cấu hình User] Xoá" , CategoryUser),
            (UserView, "[Cấu hình User] Xem" , CategoryUser),
            (UserSetRoles, "[Cấu hình User] Gán role" , CategoryUser),

            (RoleAdd, "[Cấu hình Role] Thêm", CategoryRole),
            (RoleUpdate, "[Cấu hình Role] Cập nhật", CategoryRole),
            (RoleDelete, "[Cấu hình Role] Xoá", CategoryRole),
            (RoleView, "[Cấu hình Role] Xem", CategoryRole),

            (PlanAdd, "[Cấu hình chương trình] Thêm", CategoryCauHinhPlan),
            (PlanUpdate, "[Cấu hình chương trình] Cập nhật", CategoryCauHinhPlan),
            (PlanDelete, "[Cấu hình chương trình] Xoá", CategoryCauHinhPlan),
            (PlanView, "[Cấu hình chương trình] Xem", CategoryCauHinhPlan),

            (SubPlanAdd, "[Cấu hình khoa] Thêm", CategoryCauHinhSubPlan),
            (SubPlanUpdate, "[Cấu hình khoa] Cập nhật", CategoryCauHinhSubPlan),
            (SubPlanDelete, "[Cấu hình khoa] Xoá", CategoryCauHinhSubPlan),
            (SubPlanView, "[Cấu hình khoa] Xem", CategoryCauHinhSubPlan),

            (GiaoDiennAdd, "[Cấu hình Giao diện] Thêm", CategoryCauHinhGiaoDien),
            (GiaoDienUpdate, "[Cấu hình Giao diện] Cập nhật", CategoryCauHinhGiaoDien),
            (GiaoDienDelete, "[Cấu hình Giao diện] Xoá", CategoryCauHinhGiaoDien),
            (GiaoDienView, "[Cấu hình Giao diện] Xem", CategoryCauHinhGiaoDien),

            (SlideAdd, "[Cấu hình Slide] Thêm", CategoryCauHinhSlide),
            (SlideUpdate, "[Cấu hình Slide] Cập nhật", CategoryCauHinhSlide),
            (SlideDelete, "[Cấu hình Slide] Xoá", CategoryCauHinhSlide),
            (SlideView, "[Cấu hình Slide] Xem", CategoryCauHinhSlide),

            (DieuKhienView, "[Điều khiển] Xem", CategoryMainFunction),
            (CheckinView, "[Checkin] Xem", CategoryMainFunction),

            (SlideTextAddFast, "[Chức năng chính] Thêm Slide Text nhanh", CategoryMainFunction),
            (SlideUpdateOrderTienDo, "[Chức năng chính] Cập nhật thứ tự tiến độ slide", CategoryMainFunction),
            (SlideRevertTienDo, "[Chức năng chính] Revert tiến độ trao bằng", CategoryMainFunction),
            (PushSinhVienVaoHangDoi, "[Chức năng chính] Đưa SV vào hàng đợi", CategoryMainFunction),
            (GetTienDo, "[Chức năng chính] Lấy tiến độ", CategoryMainFunction),
            (NextSubPlan, "[Chức năng chính] Chuyển sang khoa tiếp theo", CategoryMainFunction),
            (GetSubPlansOfActivePlan, "[Chức năng chính] Lấy danh sách Khoa của chương trình đang chạy", CategoryMainFunction),
            (UpdateTrangThaiSv, "[Chức năng chính] Cập nhật trạng thái sinh viên", CategoryMainFunction),
            (GetSvChuanBiNhanBang, "[Chức năng chính] Lấy danh sách SV chuẩn bị nhận bằng", CategoryMainFunction),
            (PushSlideVaoHangDoi, "[Chức năng chính] Đưa slide vào hàng đợi", CategoryMainFunction),
            (RestartActivePlan, "[Chức năng chính] Restart chương trình nhận bằng đang active", CategoryMainFunction),
            (DemoMode, "[Chức năng chính] Khởi động chế độ demo / test", CategoryMainFunction),

    };
    }
}
