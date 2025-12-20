import { IViewRowConfigPlan } from '@/models/traobang/plan.models';
import { TraoBangPlanService } from '@/service/plan.service';
import { SlideService } from '@/service/slide.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { SharedImports } from '@/shared/import.shared';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FileUploadModule } from 'primeng/fileupload';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
@Component({
    selector: 'app-upload',
    imports: [SharedImports, FileUploadModule],
    templateUrl: './upload.html',
    styleUrl: './upload.scss'
})
export class Upload extends BaseComponent {
    private _ref = inject(DynamicDialogRef);
    _slideService = inject(SlideService);
    _planService = inject(TraoBangPlanService);

    listPlan: IViewRowConfigPlan[] = [];
    selectedFile: File | null = null;

    override form: FormGroup = new FormGroup({
        IdPlan: new FormControl('', [Validators.required])
    });

    override ValidationMessages: Record<string, Record<string, string>> = {
        IdPlan: {
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

    onUploadChooseFile(event: any) {
        const files = event.files;
        if (files && files.length > 0) {
            this.selectedFile = files[0];
            console.log('File selected:', this.selectedFile);
        }
    }

    onSubmit() {
        if (this.isFormInvalid()) {
            this.messageError('Vui lòng điền đầy đủ thông tin bắt buộc');
            return;
        }

        if (!this.selectedFile) {
            this.messageError('Vui lòng chọn file để upload');
            return;
        }

        const formData = new FormData();
        formData.append('file', this.selectedFile);
        formData.append('idPlan', this.form.get('IdPlan')?.value.toString());

        this.loading = true;
        this._slideService.uploadFile(formData).subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res, true, 'Upload file thành công')) {
                    this._ref?.close(true);
                }
            },
            error: (err) => {
                this.messageError(err?.message || 'Có lỗi xảy ra khi upload file');
            },
            complete: () => {
                this.loading = false;
            }
        });
    }
}
