import { BaseComponent } from '@/shared/components/base/base-component';
import { SharedImports } from '@/shared/import.shared';
import { Component, HostListener, input, output } from '@angular/core';
import { ConfirmNext } from './confirm-next/confirm-next';

@Component({
    selector: 'app-header',
    imports: [SharedImports],
    templateUrl: './header.html',
})
export class Header extends BaseComponent {
    tenKhoa = input.required<string>()
    onNextSubPlan = output()

    @HostListener('document:keydown.control.enter', ['$event'])
    handleCtrlEnter(event: Event) {
        (event as KeyboardEvent).preventDefault();
        this.onClickNext();
    }

    onClickNext() {
        const ref = this._dialogService.open(ConfirmNext, {
            header: 'Thực hiện chuyển khoa',
            closable: true, modal: true, styleClass: 'w-[300px]', focusOnShow: false
        })
        ref.onClose.subscribe((result) => {
            if (result) {
                this.onNextSubPlan.emit()
            }
        });

        // this.confirmAction(
        //     {
        //         header: 'Thực hiện chuyển khoa',
        //         message: `Chắc chắn muốn chuyển khoa?`
        //     },
        //     () => {
        //         this.onNextSubPlan.emit()
        //     }
        // );
    }
}
