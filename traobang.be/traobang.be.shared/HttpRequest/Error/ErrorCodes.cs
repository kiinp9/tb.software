using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traobang.be.shared.HttpRequest.Error
{
    public static class ErrorCodes
    {
        //Các mã lỗi căn bản
        public const int System = 1;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int NotFound = 404;
        public const int Found = 409;
        public const int InternalServerError = 500;

        public const int AuthInvalidPassword = 101;
        public const int AuthErrorCreateUser = 102;
        public const int AuthErrorUserNotFound = 103;
        public const int AuthErrorCreateRole = 104;
        public const int AuthErrorRoleNotFound = 105;
        public const int AuthErrorUserEmailHuceNotFound = 106;


        public const int ServiceAccountErrorNotFound = 701;
        public const int GoogleSheetUrlErrorInvalid = 702;

        public const int ImportHeaderErrorInvalid = 801;
        public const int ErrorNoPermissionAccessGoogleSheet = 901;
        public const int ErrorServiceAccountNotFoundInAppSetting = 902;
        public const int ErrorServiceAccountNotFound = 903;

        public const int TraoBangErrorPlanNotFound = 1001;
        public const int TraoBangErrorSubPlanNotFound = 1002;
        public const int TraoBangErrorSubPlanOrderInvalid = 1003;
        public const int TraoBangErrorSinhVienDaTonTai = 1004;
        public const int TraoBangErrorSinhVienNotFound = 1005;
        public const int TraoBangErrorSinhVienOrderInvalid = 1006;
        public const int TraoBangErrorSinhVienDaTonTaiTrongHangDoi = 1007;
        public const int TraoBangErrorSinhVienTraoBangNotFound = 1008;
        public const int TraoBangErrorSinhVienTraoBangKhongThuocKhoaDangTrao = 1009;
    }
}
