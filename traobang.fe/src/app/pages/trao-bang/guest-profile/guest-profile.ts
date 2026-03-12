
import { IViewGuestSvNhanBang } from '@/models/guest-sv-nhan-bang.models';
import { GuestSvNhanBangService } from '@/service/guest-sv-nhan-bang';
import { BaseComponent } from '@/shared/components/base/base-component';
import { SharedImports } from '@/shared/import.shared';
import { Component, inject, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import * as signalR from '@microsoft/signalr';
import { TraoBangSvService } from '@/service/sv-nhan-bang.service';
import { ScanQrService } from '@/service/scan-qr.service';
import { SystemTraoBangService } from '@/service/system-trao-bang';
import { SubPlanStatuses, TraoBangHubConst } from '@/shared/constants/sv-nhan-bang.constants';

const STEPS = {
    PREV: -1,
    CURRENT: 0,
    NEXT: 1,
}

@Component({
    selector: 'app-guest-profile',
    imports: [SharedImports],
    templateUrl: './guest-profile.html',
    styleUrl: './guest-profile.scss'
})
export class GuestProfile extends BaseComponent implements OnDestroy {


    hubConnection: signalR.HubConnection | undefined;

    _guestService = inject(GuestSvNhanBangService);
    _route = inject(ActivatedRoute);

    mssv: string | null = null;
    step: number = STEPS.CURRENT;
    originSv: IViewGuestSvNhanBang = {}
    data: IViewGuestSvNhanBang = {}
    urlFile = environment.minioUrl
    subPlanStatuses = SubPlanStatuses

    override ngOnInit(): void {
        this.mssv = this._route.snapshot.queryParamMap.get('mssv');
        this.getProfile();
        this.connectHub();
    }

    get isShowPrevBtn() {
        return (this.step === STEPS.CURRENT && this.originSv.isShowPrev) || this.step === STEPS.NEXT
    }

    get isShowNextBtn() {
        return (this.step === STEPS.CURRENT && this.originSv.isShowNext) || this.step === STEPS.PREV
    }

    getProfile() {
        this._guestService.getByMssv(this.mssv || '').subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res)) {
                    this.data = { ...res.data }
                    this.originSv = { ...res.data }
                }
            },
            error: (err) => {
                this.messageError(err);
            }
        });
    }

    downloadQr() {
        const imageUrl = `${this.urlFile}/${this.data.linkQR || ''}`;
        this._guestService.downloadQr(imageUrl, `${this.mssv}.jpg`);
    }

    onPrev() {
        if (this.step === STEPS.CURRENT) {
            this._guestService.getPrevByMssv(this.mssv || '').subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res)) {
                        this.data = { ...res.data }
                        this.step = STEPS.PREV
                    }
                },
                error: (err) => {
                    this.messageError(err);
                }
            });
        } else if (this.step === STEPS.NEXT) {
            this.step = STEPS.CURRENT
            this.data = { ...this.originSv }
        }
    }

    onNext() {
        if (this.step === STEPS.CURRENT) {
            this._guestService.getNextByMssv(this.mssv || '').subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res)) {
                        this.data = { ...res.data }
                        this.step = STEPS.NEXT
                    }
                },
                error: (err) => {
                    this.messageError(err);
                }
            });
        } else if (this.step === STEPS.PREV) {
            this.step = STEPS.CURRENT
            this.data = { ...this.originSv }
        }
    }

    ngOnDestroy(): void {
        this.hubConnection?.stop().then();
    }

    connectHub() {
        const hubUrl = TraoBangHubConst.HUB;
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl, {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets
            })
            .build();

        this.hubConnection.on(TraoBangHubConst.ReceiveSinhVienDangTrao, (...args) => {
            const idSubPlan = args[0];

            // if (!idSubPlan) return;

            this.getProfile();
        });

        this.hubConnection.start().then();
    }
}
