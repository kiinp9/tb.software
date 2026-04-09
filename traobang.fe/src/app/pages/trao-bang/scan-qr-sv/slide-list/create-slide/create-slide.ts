import { SlideDragDropService } from '@/service/slide-drag-drop.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { SharedImports } from '@/shared/import.shared';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PickListModule } from 'primeng/picklist';

@Component({
    selector: 'app-create-slide',
    imports: [SharedImports, PickListModule],
    templateUrl: './create-slide.html',
    styleUrl: './create-slide.scss'
})
export class CreateSlide extends BaseComponent {
    private _ref = inject(DynamicDialogRef);
    private _config = inject(DynamicDialogConfig);
    private _slideDragService = inject(SlideDragDropService);


    override ngOnInit(): void {
        console.log(this._config.data)
    }


    override form: FormGroup = new FormGroup({
        idSubPlan: new FormControl(this._config.data?.idSubPlan, [Validators.required]),
        noiDung: new FormControl([], [Validators.required]),
        IdSlideTruoc: new FormControl(this._config.data?.IdSlideTruoc),
        note: new FormControl('', [Validators.required]),
    });

    override ValidationMessages: Record<string, Record<string, string>> = {
        noiDung: {
            required: 'Không được bỏ trống'
        },
        note: {
            required: 'Không được bỏ trống'
        },

    };

    getFormError(field: string) {
        return this.getErrorMessage(this.form.get(field), field);
    }


    onSubmit() {
        if (this.isFormInvalid()) {
            return;
        }
        this.onSubmitCreate();
    }

    onSubmitCreate() {
        const body: any = {
            ...this.form.value,
        };
        this.loading = true;
        this._slideDragService.createFastSlide(body).subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res, true, 'Đã thêm slide')) {
                    this._ref?.close(true);
                }
            },
            error: (err) => {
                this.messageError(err?.message);
            },
            complete: () => {
                this.loading = false;
            }
        });
    }
    onClose() {
        this._ref.close()
    }
}


