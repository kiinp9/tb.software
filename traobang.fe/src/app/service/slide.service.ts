import { inject, Injectable } from "@angular/core";
import { IBaseResponse, IBaseResponsePaging, IBaseResponseWithData } from '@/shared/models/request-paging.base.models';
import { HttpClient } from '@angular/common/http';
import { ICreateSlide, IFindPagingSlide, IUpdateSlide, IViewRowSlide } from "@/models/traobang/slide.models";
@Injectable({
    providedIn: 'root'
})

export class SlideService {
    api = '/api/config/slide';
    http = inject(HttpClient);

    findPaging(query: IFindPagingSlide) {
        return this.http.get<IBaseResponsePaging<IViewRowSlide>>(this.api, {
            params: { ...query }
        });
    }

    getById(id: string) {
        return this.http.get<IBaseResponseWithData<IViewRowSlide>>(`${this.api}/${id}`);
    }

    getList() {
        return this.http.get<IBaseResponseWithData<IViewRowSlide[]>>(`${this.api}/list`);
    }

    create(body: ICreateSlide) {
        return this.http.post<IBaseResponse>(`${this.api}`, body);
    }

    update(body: IUpdateSlide) {
        return this.http.put<IBaseResponse>(`${this.api}`, body);
    }
}
