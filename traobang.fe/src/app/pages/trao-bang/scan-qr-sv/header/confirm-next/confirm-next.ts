import { SharedImports } from '@/shared/import.shared';
import { Component, HostListener, inject } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
    selector: 'app-confirm-next',
    imports: [SharedImports],
    templateUrl: './confirm-next.html',
    styleUrl: './confirm-next.scss'
})
export class ConfirmNext {

    private _ref = inject(DynamicDialogRef);

    @HostListener('document:keydown.enter', ['$event'])
    handleCtrlEnter(event: Event) {
        (event as KeyboardEvent).preventDefault();
        this.onSubmit();
    }

    onClose() {
        this._ref.close(false)
    }
    onSubmit() {
        this._ref.close(true)
    }
}
