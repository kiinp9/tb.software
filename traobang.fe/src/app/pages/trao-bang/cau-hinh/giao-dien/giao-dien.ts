import { GiaoDienService } from '@/service/giao-dien.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { CellViewTypes } from '@/shared/constants/data-table.constants';
import { IColumn } from '@/shared/models/data-table.models';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TblAction } from './tbl-action/tbl-action';
import { IFindPagingGiaoDien, IViewGiaoDien } from '@/models/traobang/giao-dien.models';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { TblActionTypes } from '../plan/tbl-action/tbl-action';
import { SharedImports } from '@/shared/import.shared';
import { DataTable } from '@/shared/components/data-table/data-table';
import { PaginatorState } from 'primeng/paginator';

@Component({
    selector: 'app-giao-dien',
    imports: [SharedImports, DataTable],
    templateUrl: './giao-dien.html',
    styleUrl: './giao-dien.scss'
})

export class GiaoDien extends BaseComponent {
    _giaoDienService = inject(GiaoDienService);

    searchForm: FormGroup = new FormGroup({
        search: new FormControl(''),
    });

    columns: IColumn[] = [
        { header: 'STT', cellViewType: CellViewTypes.INDEX, headerContainerStyle: 'width: 6rem' },
        { header: 'Tên giao diện', field: 'tenGiaoDien', headerContainerStyle: 'min-width: 10rem' },
        { header: 'Mô tả', field: 'moTa', headerContainerStyle: 'min-width: 10rem' },
        { header: 'Thao tác', headerContainerStyle: 'width: 6rem', cellViewType: CellViewTypes.CUSTOM_COMP, customComponent: TblAction }
    ];

    data: IViewGiaoDien[] = [];

    query: IFindPagingGiaoDien = {
        pageNumber: this.START_PAGE_NUMBER,
        pageSize: this.MAX_PAGE_SIZE
    };

    override ngOnInit(): void {
        this.getData()
        this.searchForm
            .get('search')
            ?.valueChanges.pipe(debounceTime(500), distinctUntilChanged())
            .subscribe(() => {
                this.getData();
            });
    }

    onSearch() {
        this.getData();
    }

    getData() {
        this.loading = true;
        this._giaoDienService
            .findPaging({ ...this.query, keyword: this.searchForm.get('search')?.value })
            .subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, false)) {
                        this.data = res.data.items
                        this.totalRecords = res.data.totalItems;
                    }
                }
            })
            .add(() => {
                this.loading = false;
            });
    }

    onPageChanged($event: PaginatorState) {
        this.query.pageNumber = ($event.page ?? 0) + 1;
        this.getData();
    }

    onOpenCreate() {
        this.router.navigate(['trao-bang/config/giao-dien/create'], {});
    }

    onOpenUpdate(data: any) {
        this.router.navigate(['trao-bang/config/giao-dien/create'], {
            queryParams: {
                id: encodeURIComponent(JSON.stringify(data.id))
            }
        });
    }

    onCustomEmit(data: { type: string; data: IViewGiaoDien; field?: string }) {
        if (data.type === TblActionTypes.update) {
            this.onOpenUpdate(data.data);
        } else if (data.type === TblActionTypes.delete) {
            this.onDelete(data.data);
        }
    }

    onDelete(data: IViewGiaoDien) {
        this.confirmDelete(
            {
                header: 'Bạn chắc chắn muốn xóa SV?',
                message: 'Không thể khôi phục sau khi xóa'
            },
            () => {
                this._giaoDienService.delete(data.id || 0).subscribe(
                    (res) => {
                        if (this.isResponseSucceed(res, true, 'Đã xóa')) {
                            this.getData();
                        }
                    },
                    (err) => {
                        this.messageError(err?.message);
                    }
                );
            }
        );
    }
}
