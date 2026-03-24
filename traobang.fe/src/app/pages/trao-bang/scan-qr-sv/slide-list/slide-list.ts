import { ISlideItem, IViewScanQrCurrentSubPlan } from '@/models/traobang/sv-nhan-bang.models';
import { BaseComponent } from '@/shared/components/base/base-component';
import { SvNhanBangStatuses } from '@/shared/constants/sv-nhan-bang.constants';
import { SharedImports } from '@/shared/import.shared';
import { Component, input, output, signal } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { CreateSlide } from './create-slide/create-slide';

@Component({
    selector: 'app-slide-list',
    imports: [SharedImports, TableModule, TagModule],
    templateUrl: './slide-list.html',
    styleUrl: './slide-list.scss'
})
export class SlideList extends BaseComponent {
    slides = input.required<ISlideItem[]>();
    idSubPlan = input<number>();
    removingFirst = input<boolean>(false);
    constStatuses = SvNhanBangStatuses;
    createSuccess = output<any>();

    onOpenCreateSlide() {
        const ref = this._dialogService.open(CreateSlide,
            {
                header: 'Tạo slide',
                closable: true,
                modal: true,
                styleClass: 'w-[500px]',
                focusOnShow: false,
                data: {
                    idSubPlan: this.idSubPlan(),
                    IdSlideTruoc: this.slides().at(-1)?.id
                }
            });
        ref.onClose.subscribe((res) => {
            if (res) {
                this.createSuccess.emit(true)
            }
        });
    }

    onDeleteSlide(slideId: number | undefined) {
        if (!slideId) return;
        this.confirmAction(
            {
                header: 'Xóa slide',
                message: 'Bạn chắc chắn muốn xóa slide này?'
            },
            () => {
                // Call API to delete slide
                console.log('Delete slide:', slideId);
                this.createSuccess.emit(true);
            }
        );
    }
}
