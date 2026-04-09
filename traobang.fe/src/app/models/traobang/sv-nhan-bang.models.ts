import { IBaseRequestPaging } from "@/shared/models/request-paging.base.models";

export interface IViewRowSvNhanBang {
    id?: number;
    idSubPlan?: number;
    tenSubPlan?: string;
    hoVaTen?: string;
    email?: string;
    emailSinhVien?: string;
    maSoSinhVien?: string;
    lop?: string;
    ngaySinh?: string; // ISO datetime string
    capBang?: string;
    tenNganhDaoTao?: string;
    xepHang?: string;
    thanhTich?: string;
    khoaQuanLy?: string;
    soQuyetDinhTotNghiep?: string;
    ngayQuyetDinh?: string; // ISO datetime string
    note?: string;
    isShow?: boolean;
    order?: string; // string in your data ("1")
    trangThai?: number;
    linkQR?: string;
}

export interface IFindPagingSvNhanBang extends IBaseRequestPaging {
    IdSubPlan?: number
}

export interface ICreateSvNhanBang {
    idSubPlan: number;
    hoVaTen: string;
    email: string;
    emailSinhVien: string;
    maSoSinhVien: string;
    lop: string;
    ngaySinh: string; // ISO datetime string
    capBang: string;
    tenNganhDaoTao: string;
    xepHang: string;
    thanhTich: string;
    khoaQuanLy: string;
    soQuyetDinhTotNghiep: string;
    ngayQuyetDinh: string; // ISO datetime string
    note: string;
    trangThai: number;
    linkQR: string;
}

export interface IUpdateSvNhanBang extends ICreateSvNhanBang {
    id: number;
}

export interface IGetTienDoHangDoi {
    // IdSubPlan: number;
    SoLuong?: number;
}
export interface IGetTienDoHangDoiSinhVienBatDauLui {
    Mssv: string;
    SoLuong?: number;
}

export interface IViewScanQrCurrentSubPlan {
    soLuongConLai?: number
    soLuongDaTrao?: number
    soLuongThamGia?: number
    soLuongVangMat?: number
    ten?: string
    idPlan?:number
    slideTexts?: ISlideItem[]
}

export interface IViewScanQrTienDoSv {
    id?: number;
    hoVaTen?: string;
    maSoSinhVien?: string;
    isShow?: boolean;
    orderTienDo?: number;
    orderDanhSachNhanBang?: number;
    trangThai?: number;
    capBang?: string;
    idSlide?:number
    tenKhoa?: string;
    loaiSlide?:number;
    isSlideDauCuoi?:Boolean
}

export interface IViewScanQrSubPlan {
    id?: number;
    ten?: string;
    tienDo?: string;
    trangThai?: number;
    order?: number;
}

export interface IViewSvDangTraoBang {
    id?: number;
    hoVaTen?: string;
    capBang?: string;
    tenNganhDaoTao?: string;
    thanhTich?: string;
    xepHang?: string;
    maSoSinhVien?: string;
    tenSubPlan?: string;
    note?: string;
    text?: string;
    textNote?: string;
    infoType?: number;
}

export interface IViewTienDoTraoBang {
    tienDo: string
}

export interface IViewSubPlanSideScreen {
    id?: number
    ten?: string
    tienDo?: string
    orderTienDo?:number;
    items?: IViewScanQrTienDoSv[]
}
export interface IViewSvBatDauLuiResponse {
    svBatDauLui?: IViewSvDangTraoBang;
    svChuanBiTiepTheo?: IViewSvDangTraoBang;
}

export interface ISlideItem {
    id: number;
    idSubPlan: number;
    loaiSlide: number;
    idSinhVienNhanBang: number | null;
    noiDung: string;
    note: string;
    trangThai: number;
    order: number;
    isShow: boolean;
    createdBy: string;
    createdDate: string; // hoặc Date nếu bạn parse sang Date
    sinhVien: any | null; // đổi thành interface cụ thể nếu có model sinhVien
}
