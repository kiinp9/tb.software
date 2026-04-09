import { Routes } from "@angular/router";
import { permissionGuard } from "@/shared/guard/permission-guard";
import { PermissionConstants } from "@/shared/constants/permission.constants";
import { Plan } from "./cau-hinh/plan/plan";
import { SubPlan } from "./cau-hinh/sub-plan/sub-plan";
import { SvNhanBang } from "./cau-hinh/sv-nhan-bang/sv-nhan-bang";
import { ScanQrSv } from "./scan-qr-sv/scan-qr-sv";
import { McScreen } from "./mc-screen/mc-screen";
import { SlideScreen } from "./cau-hinh/slide/slide";
import { GiaoDien } from "./cau-hinh/giao-dien/giao-dien";
import { CreateGiaoDien } from "./cau-hinh/giao-dien/create-giao-dien/create-giao-dien";

export default [
    { path: 'config/plan', title: 'Chương trình', data: { breadcrumb: 'plan', permission: PermissionConstants.MenuCauHinhChuongTrinh }, component: Plan, canActivate: [permissionGuard], },
    { path: 'config/sub-plan', title: 'Khoa', data: { breadcrumb: 'sub-plan', permission: PermissionConstants.MenuCauHinhKhoa }, component: SubPlan, canActivate: [permissionGuard] },
    { path: 'scan-qr-sv', title: 'Checkin', data: { breadcrumb: 'scan-qr-sv', permission: PermissionConstants.MenuManHinhCheckin }, component: ScanQrSv, canActivate: [permissionGuard] },
    { path: 'mc-screen', title: 'Điều khiển', data: { breadcrumb: 'mc-screen', permission: PermissionConstants.MenuManHinhDieuKhien }, component: McScreen, canActivate: [permissionGuard] },
    { path: 'config/slide', title: 'Slide', data: { breadcrumb: 'slide', permission: PermissionConstants.MenuCauHinhSlide }, component: SlideScreen, canActivate: [permissionGuard] },
    { path: 'config/giao-dien', title: 'Giao diện', data: { breadcrumb: 'giao-dien', permission: PermissionConstants.MenuCauHinhGiaoDien }, component: GiaoDien, canActivate: [permissionGuard] },
    { path: 'config/giao-dien/create', title: 'Tạo giao diện', data: { breadcrumb: 'edit-giao-dien', permission: PermissionConstants.MenuCauHinhGiaoDien }, component: CreateGiaoDien, canActivate: [permissionGuard] },
] as Routes
