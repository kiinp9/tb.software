import { ICreateGiaoDien, IFindPagingGiaoDien, IUpdateGiaoDien, IViewGiaoDien } from '@/models/traobang/giao-dien.models';
import { IBaseResponse, IBaseResponsePaging, IBaseResponseWithData } from '@/shared/models/request-paging.base.models';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class GiaoDienService {
    api = '/api/core/trao-bang/giao-dien';
    http = inject(HttpClient);

    findPaging(query: IFindPagingGiaoDien, dataFilter?: any) {
        return this.http.get<IBaseResponsePaging<IViewGiaoDien>>(this.api, {
            params: { ...query, ...dataFilter }
        });
    }

    getById(id: string) {
        return this.http.get<IBaseResponseWithData<IViewGiaoDien>>(`${this.api}/${id}`);
    }

    getList() {
        return this.http.get<IBaseResponseWithData<IViewGiaoDien[]>>(`${this.api}/list`);
    }

    create(body: ICreateGiaoDien) {
        return this.http.post<IBaseResponseWithData<any>>(`${this.api}`, body);
    }

    update(body: IUpdateGiaoDien) {
        return this.http.put<IBaseResponse>(`${this.api}`, body);
    }

    delete(id: number) {
        return this.http.delete<IBaseResponse>(`${this.api}/${id}`);
    }
}
