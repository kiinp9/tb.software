import { IBaseRequestPaging } from '@/shared/models/request-paging.base.models';

export interface IViewRowConfigPlan {
    id?: number;
    ten?: string;
    moTa?: string;
    trangThai?: number;
    trangThaiText?: string;
    thoiGianBatDau?: string;
    thoiGianKetThuc?: string;
    createdDate?: string;
}

export interface IFindPagingConfigPlan extends IBaseRequestPaging {}

export interface ICreateConfigPlan {
    ten: string;
    moTa?: string;
    thoiGianBatDau?: string;
    thoiGianKetThuc?: string;
}

export interface IUpdateConfigPlan extends ICreateConfigPlan {
    id: number;
}

export class PlanTrangThai {
    static KHOI_TAO = 1;
    static DANG_HOAT_DONG = 2;
    static DA_KET_THUC = 3;

    static ListTrangThai = [
        {
            name: 'Khởi tạo',
            code: PlanTrangThai.KHOI_TAO,
            severity: 'secondary'
        },
        {
            name: 'Đang hoạt động',
            code: PlanTrangThai.DANG_HOAT_DONG,
            severity: 'info'
        },
        {
            name: 'Đã kết thúc',
            code: PlanTrangThai.DA_KET_THUC,
            severity: 'danger'
        }
    ];

    static getSeverity(code: number) {
        const found = this.ListTrangThai.find((x) => x.code === code);
        return typeof found != 'undefined' ? found.severity : '';
    }

    static getName(code: number) {
        const found = this.ListTrangThai.find((x) => x.code === code);
        return typeof found != 'undefined' ? found.name : '';
    }
}
