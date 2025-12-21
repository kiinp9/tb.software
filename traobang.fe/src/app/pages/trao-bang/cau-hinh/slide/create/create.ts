import { SinhVien } from './../../../../../models/traobang/slide.models';
import { ICreateSlide, IUpdateSlide, IViewRowSlide } from '@/models/traobang/slide.models';
import { IViewRowConfigSubPlan } from '@/models/traobang/sub-plan.models';
import { SlideService } from '@/service/slide.service';
import { TraoBangSubPlanService } from '@/service/sub-plan.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { SlideConst, SvNhanBangStatuses } from '@/shared/constants/sv-nhan-bang.constants';
import { SharedImports } from '@/shared/import.shared';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PickListModule } from 'primeng/picklist';

@Component({
    selector: 'app-create',
    imports: [SharedImports, PickListModule],
    templateUrl: './create.html',
    styleUrl: './create.scss'
})
export class Create extends BaseComponent {
    private _ref = inject(DynamicDialogRef);
    private _config = inject(DynamicDialogConfig);
    private _slideService = inject(SlideService);
    private _subPlanService = inject(TraoBangSubPlanService);

    listLoaiSlide = SlideConst.listLoaiSlide;

    listSvTrangThai = SvNhanBangStatuses.List;
    listTrangThai = SvNhanBangStatuses.List;

    listRole: IViewRowSlide[] = [];
    listSubPlan: IViewRowConfigSubPlan[] = [];
    isStudent: boolean = false;

    override form: FormGroup = new FormGroup({
        idSubPlan: new FormControl('', [Validators.required]),
        loaiSlide: new FormControl(SlideConst.TEXT, [Validators.required]),
        noiDung: new FormControl([], [Validators.required]),
        note: new FormControl('', [Validators.required]),
        trangThai: new FormControl('', [Validators.required]),
        isShow: new FormControl(true)
    });

    studentForm = new FormGroup({
        hoVaTen: new FormControl('', [Validators.required]),
        maSoSinhVien: new FormControl('', [Validators.required]),
        email: new FormControl(''),
        emailSinhVien: new FormControl(''),
        lop: new FormControl(''),
        ngaySinh: new FormControl(new Date()),
        capBang: new FormControl(''),
        tenNganhDaoTao: new FormControl(''),
        xepHang: new FormControl(''),
        thanhTich: new FormControl(''),
        khoaQuanLy: new FormControl(''),
        soQuyetDinhTotNghiep: new FormControl(''),
        ngayQuyetDinh: new FormControl(new Date()),
        note: new FormControl(''),
        linkQR: new FormControl(''),
        id: new FormControl('')
    });

    override ValidationMessages: Record<string, Record<string, string>> = {
        loaiSlide: {
            required: 'Vui lòng chọn loại slide'
        },
        idSubPlan: {
            required: 'Vui lòng chọn khoa'
        },
        trangThai: {
            required: 'Vui lòng chọn trạng thái'
        },
        noiDung: {
            required: 'Không được bỏ trống'
        },
        note: {
            required: 'Không được bỏ trống'
        },
        email: {
            required: 'Không được bỏ trống'
        },
        hoVaTen: {
            required: 'Không được bỏ trống'
        },
        maSoSinhVien: {
            required: 'Không được bỏ trống'
        },
        emailSinhVien: {
            required: 'Không được bỏ trống'
        },
        lop: {
            required: 'Không được bỏ trống'
        },
        ngaySinh: {
            required: 'Không được bỏ trống'
        },
        tenNganhDaoTao: {
            required: 'Không được bỏ trống'
        },
        xepHang: {
            required: 'Không được bỏ trống'
        },
        thanhTich: {
            required: 'Không được bỏ trống'
        },
        khoaQuanLy: {
            required: 'Không được bỏ trống'
        },
        soQuyetDinhTotNghiep: {
            required: 'Không được bỏ trống'
        },
        ngayQuyetDinh: {
            required: 'Không được bỏ trống'
        },
        linkQR: {
            required: 'Không được bỏ trống'
        }
    };

    getStudentError(field: string) {
        return this.getErrorMessage(this.studentForm.get(field), field);
    }

    get isUpdate() {
        return this._config.data?.id;
    }

    override ngOnInit(): void {
        console.log(this._config.data);
        this.getListSubPlan();
        if (this.isUpdate) {
            this.form.setValue({
                idSubPlan: this._config.data.idSubPlan,
                noiDung: this._config.data.noiDung,
                loaiSlide: this._config.data.loaiSlide,
                note: this._config.data.note,
                trangThai: this._config.data.trangThai,
                isShow: this._config.data.isShow
            });
            if (this._config.data.loaiSlide == SlideConst.SinhVien) {
                this.isStudent = true;
                this.studentForm.setValue({
                    hoVaTen: this._config.data.sinhVien.hoVaTen,
                    maSoSinhVien: this._config.data.sinhVien.maSoSinhVien,
                    email: this._config.data.sinhVien.email,
                    emailSinhVien: this._config.data.sinhVien.emailSinhVien,
                    lop: this._config.data.sinhVien.lop,
                    ngaySinh: new Date(this._config.data.sinhVien.ngaySinh),
                    capBang: this._config.data.sinhVien.capBang,
                    tenNganhDaoTao: this._config.data.sinhVien.tenNganhDaoTao,
                    xepHang: this._config.data.sinhVien.xepHang,
                    thanhTich: this._config.data.sinhVien.thanhTich,
                    khoaQuanLy: this._config.data.sinhVien.khoaQuanLy,
                    soQuyetDinhTotNghiep: this._config.data.sinhVien.soQuyetDinhTotNghiep,
                    ngayQuyetDinh: new Date(this._config.data.sinhVien.ngayQuyetDinh),
                    note: this._config.data.sinhVien.note,
                    linkQR: this._config.data.sinhVien.linkQR,
                    id : this._config.data.sinhVien.id
                });
            }
        }
    }

    getListSubPlan() {
        this._subPlanService.getListSubPlanActive().subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res)) {
                    this.listSubPlan = res.data;
                }
            }
        });
    }

    onChangeLoaiSlide() {
        if (this.form.get('loaiSlide')?.value == SlideConst.SinhVien) {
            this.isStudent = true;
        } else {
            this.isStudent = false;
        }
    }

    isFormStudentInvalid() {
        if (this.studentForm.invalid) {
            this.studentForm.markAllAsTouched();
            return true;
        }
        return false;
    }

    onSubmit() {
        // Mark all fields as touched to trigger validation display
        this.form.markAllAsTouched();

        if (!this.isStudent) {
            if (this.isFormInvalid()) {
                this.messageError('Vui lòng kiểm tra và điền đầy đủ thông tin bắt buộc');
                return;
            }
            if (this.isUpdate) {
                this.onSubmitUpdate();
            } else {
                this.onSubmitCreate();
            }
        } else {
            this.studentForm.markAllAsTouched();
            if (this.isFormInvalid() || this.isFormStudentInvalid()) {
                this.messageError('Vui lòng kiểm tra và điền đầy đủ thông tin bắt buộc');
                return;
            }
            if (this.isUpdate) {
                this.onSubmitUpdate();
            } else {
                this.onSubmitCreate();
            }
        }
    }

    onSubmitUpdate() {
        this.loading = true;
        let body: IUpdateSlide;

        if (!this.isStudent) {
            body = {
                id: this._config.data.id,
                ...this.form.value
            };
        } else {
            body = {
                id: this._config.data.id,
                ...this.form.value,
                sinhVien: {
                    ...this.studentForm.value
                }
            };
        }
        // console.log(body);
        this._slideService.update(body).subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res, true, 'Đã lưu')) {
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

    onSubmitCreate() {
        this.loading = true;
        let body: ICreateSlide;
        if (!this.isStudent) {
            body = {
                ...this.form.value
            };
        } else {
            body = {
                ...this.form.value,
                sinhVien: {
                    ...this.studentForm.value
                }
            };
        }
        // console.log(body);
        this._slideService.create(body).subscribe({
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
}
