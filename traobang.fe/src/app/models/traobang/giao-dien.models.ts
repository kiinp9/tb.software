import { IBaseRequestPaging } from "@/shared/models/request-paging.base.models";

export interface IViewGiaoDien {
    id?: number;
    tenGiaoDien?: string;
    moTa?: string;
    noiDung?: string;
}

export interface ICreateGiaoDien {
    tenGiaoDien?: string;
    moTa?: string;
    noiDung?: string;
}

export interface IUpdateGiaoDien extends ICreateGiaoDien {
    id?: number
}

export interface IFindPagingGiaoDien extends IBaseRequestPaging { }
