using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traobang.be.shared.Constants.Auth
{
     public static class PermissionKeys
    {
        public const string Menu = "Menu.";
        public const string Function = "Function.";


        public const string MenuTraoBang = Menu + "TraoBang";
        public const string MenuUserManagement = Menu + "UserManagement";
        public const string MenuUserManagementUser = MenuUserManagement + "_User";
        public const string MenuUserManagementRole = MenuUserManagement + "_User";

        public const string MenuTraoBangCauHinh = MenuTraoBang + "_CauHinh";
        public const string MenuTraoBangCauHinhChuongTrinh = MenuTraoBangCauHinh + "_ChuongTrinh";
        public const string MenuTraoBangCauHinhKhoa = MenuTraoBangCauHinh + "_Khoa";
        public const string MenuTraoBangCauHinhSinhVienNhanBang = MenuTraoBangCauHinh + "_SinhVienNhanBang";
        public const string MenuTraoBangQuetQr = MenuTraoBang + "_QuetQr";
        public const string MenuTraoBangMc = MenuTraoBang + "_Mc";


        public const string CategoryUser = "QL User";
        public const string UserAdd = Function + "UserAdd";
        public const string UserUpdate = Function + "UserUpdate";
        public const string UserDelete = Function + "UserDelete";
        public const string UserView = Function + "UserView";
        public const string UserSetRoles = Function + "UserSetRoles";

        public const string CategoryRole = "QL Role";
        public const string RoleAdd = Function + "Add";
        public const string RoleUpdate = Function + "Update";
        public const string RoleDelete = Function + "Delete";
        public const string RoleView = Function + "View";


        public const string CategoryPlan = "QL Plan";
        public const string PlanAdd = Function + "PlanAdd";
        public const string PlanUpdate = Function + "PlanUpdate";
        public const string PlanDelete = Function + "PlanDelete";
        public const string PlanView = Function + "PlanView";

        public const string CategorySubPlan = "QL SubPlan";
        public const string SubPlanAdd = Function + "SubPlanAdd";
        public const string SubPlanUpdate = Function + "SubPlanUpdate";
        public const string SubPlanDelete = Function + "SubPlanDelete";
        public const string SubPlanView = Function + "SubPlanView";

        public static readonly (string Key, string Name, string Category)[] All =
        {

            (MenuUserManagement, "Menu Quản lý User", "Menu"),
            (MenuUserManagementUser, "Menu Quản lý User - User", "Menu"),
            (MenuUserManagementRole, "Menu Quản lý User - Role", "Menu"),
            (MenuTraoBang, "Menu Trao Bằng", "Menu"),


            (MenuTraoBangCauHinh, "Menu Trao Bằng Cấu hình", "Menu"),
            (MenuTraoBangCauHinhChuongTrinh, "Menu Trao Bằng Cấu hình Chương trình", "Menu"),
            (MenuTraoBangCauHinhKhoa, "Menu Trao Bằng Cấu hình Khoa", "Menu"),
            (MenuTraoBangCauHinhSinhVienNhanBang, "Menu Trao Bằng Cấu hình Sinh viên", "Menu"),
            (MenuTraoBangQuetQr, "Menu Trao Bằng Quét QR", "Menu"),
            (MenuTraoBangMc, "Menu Trao Bằng Điều khiển", "Menu"),


            (UserAdd, "Thêm user", CategoryUser),
            (UserUpdate, "Cập nhật User" , CategoryUser),
            (UserDelete, "Xoá User" , CategoryUser),
            (UserView, "Xem User" , CategoryUser),
            (UserSetRoles, "Gán role cho User" , CategoryUser),

            (RoleAdd, "Thêm Role", CategoryRole),
            (RoleUpdate, "Cập nhật Role", CategoryRole),
            (RoleDelete, "Xoá Role", CategoryRole),
            (RoleView, "Xem Role", CategoryRole),

            (PlanAdd, "Thêm Plan ", CategoryPlan),
            (PlanUpdate, "Cập nhật Plan", CategoryPlan),
            (PlanDelete, "Xoá Plan", CategoryPlan),
            (PlanView, "Xem Plan", CategoryPlan),

            (SubPlanAdd, "Thêm SubPlan ", CategorySubPlan),
            (SubPlanUpdate, "Cập nhật SubPlan", CategorySubPlan),
            (SubPlanDelete, "Xoá SubPlan", CategorySubPlan),
            (SubPlanView, "Xem SubPlan", CategorySubPlan),


        };



    }
}
