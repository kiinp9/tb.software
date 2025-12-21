
import { IFindPagingConfigSubPlan, IViewRowConfigSubPlan, ICreateConfigSubPlan, IUpdateConfigSubPlan } from '@/models/traobang/sub-plan.models';
import { IBaseResponse, IBaseResponsePaging, IBaseResponseWithData } from '@/shared/models/request-paging.base.models';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class TraoBangSubPlanService {
    api = '/api/core/trao-bang/sub-plan';
    http = inject(HttpClient);

    findPaging(query: IFindPagingConfigSubPlan, dataFilter?: any) {
        return this.http.get<IBaseResponsePaging<IViewRowConfigSubPlan>>(this.api, {
            params: { ...query, ...dataFilter }
        });
    }

    getById(id: string) {
        return this.http.get<IBaseResponseWithData<IViewRowConfigSubPlan>>(`${this.api}/${id}`);
    }

    getList(idPlan: number) {
        return this.http.get<IBaseResponseWithData<IViewRowConfigSubPlan[]>>(`${this.api}/plan/${idPlan}/list`);
    }

    create(body: ICreateConfigSubPlan) {
        return this.http.post<IBaseResponse>(`${this.api}/${body.idPlan}`, body);
    }

    update(body: IUpdateConfigSubPlan) {
        return this.http.put<IBaseResponse>(`${this.api}`, body);
    }

    delete(id: number, idPlan: number) {
        return this.http.delete<IBaseResponse>(`${this.api}/${id}/plan/${idPlan}`);
    }

    downloadFileTemplate() {
        return this.http.get(`${this.api}/export/template-import-subplan`, { responseType: 'blob' });
    }

    uploadFile(body: any) {
        return this.http.post<IBaseResponse>(`${this.api}/import/sub-plan`, body);
    }

    getListSubPlanActive() {
        return this.http.get<IBaseResponseWithData<IViewRowConfigSubPlan[]>>(`${this.api}/plan/active/list-sub-plan-infor`);
    }

}
