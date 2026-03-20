import { IViewRowConfigPlan } from '@/models/traobang/plan.models';
import { TraoBangPlanService } from '@/service/plan.service';
import { SlideService } from '@/service/slide.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { SharedImports } from '@/shared/import.shared';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
    selector: 'app-gen-qr-code',
    imports: [SharedImports],
    templateUrl: './gen-qr-code.html',
    styleUrl: './gen-qr-code.scss'
})
export class GenQrCode extends BaseComponent {
    private _ref = inject(DynamicDialogRef);
    _slideService = inject(SlideService);
    _planService = inject(TraoBangPlanService);


    listPlan: IViewRowConfigPlan[] = [];

    override form: FormGroup = new FormGroup({
        idPlan: new FormControl('', [Validators.required])
    });

    override ValidationMessages: Record<string, Record<string, string>> = {
        idPlan: {
            required: 'Vui lòng chọn chương trình'
        }
    };

    override ngOnInit(): void {
        this.getListPlan();
    }

    getListPlan() {
        this._planService.getList().subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res)) {
                    this.listPlan = res.data;
                }
            }
        });
    }

    onSubmit() {
        if (this.isFormInvalid()) {
            this.messageError('Vui lòng điền đầy đủ thông tin bắt buộc');
            return;
        }
        let body = this.form.value
        this.loading = true;
        this._slideService.genQrCodeBySlide(body).subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res, true, 'Tạo mã QR thành công')) {
                    this._ref?.close(true);
                }
            },
            error: (err) => {
                this.messageError(err?.message || 'Có lỗi xảy ra khi tạo mã QR');
            },
            complete: () => {
                this.loading = false;
            }
        });
    }
}
