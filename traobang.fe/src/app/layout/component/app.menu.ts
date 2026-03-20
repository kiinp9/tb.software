import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AppMenuitem } from './app.menuitem';
import { IAppMenuItem } from '../model/app-menu-item.model';

import { PermissionConstants } from '@/shared/constants/permission.constants';
import { SharedService } from '@/service/shared.service';



@Component({
    selector: 'app-menu',
    standalone: true,
    imports: [CommonModule, AppMenuitem, RouterModule],
    template: `
    <div class="flex flex-col h-full">
        <ul class="layout-menu flex-1">
            <ng-container *ngFor="let item of model; let i = index">
                <li app-menuitem *ngIf="!item.separator" [item]="item" [index]="i" [root]="true"></li>
                <li *ngIf="item.separator" class="menu-separator"></li>
            </ng-container>
        </ul>

    </div>
    `
})
export class AppMenu {

    _sharedService = inject(SharedService);


    model: IAppMenuItem[] = [];
    loading = false;

    ngOnInit() {
        this.model = [
            {
                items: [
                    {
                        label: 'Màn hình',
                        expanded: true,
                        icon: "pi pi-desktop",
                        styleClass: 'header-label',
                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBang),
                        items: [
                            {
                                label: 'Sân khấu',
                                routerLink: ['/guest/trao-bang/main-screen'],
                                visible: true,
                                icon: 'pi pi-expand'
                            },
                            {
                                label: 'Cánh gà',
                                routerLink: ['/guest/trao-bang/side-screen'],
                                visible: true,
                                heroIcon: 'heroBarsArrowUp'
                            },
                            {
                                label: 'Điều khiển',
                                routerLink: ['/trao-bang/mc-screen'],
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangMc),
                                icon: 'pi pi-arrow-right-arrow-left'
                            },
                            {
                                label: 'Checkin',
                                routerLink: ['/trao-bang/scan-qr-sv'],
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangQuetQr),
                                icon: 'pi pi-qrcode'
                            },
                        ]
                    },
                    {
                        label: 'Cấu hình',
                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinh),
                        expanded: true,
                        styleClass: 'header-label',
                        icon: 'pi pi-cog',
                        items: [
                            {
                                label: 'Chương trình',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhChuongTrinh),
                                routerLink: ['/trao-bang/config/plan'],
                                icon: 'pi pi-list'
                            },
                            {
                                label: 'Khoa',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhKhoa),
                                routerLink: ['/trao-bang/config/sub-plan'],
                                icon: 'pi pi-building-columns'
                            },
                            // {
                            //     label: 'SV nhận bằng',
                            //     visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhSinhVienNhanBang),
                            //     routerLink: ['/trao-bang/config/sv']
                            // },
                            {
                                label: 'Slide',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhSinhVienNhanBang),
                                routerLink: ['/trao-bang/config/slide'],
                                icon: 'pi pi-images'
                            },
                            {
                                label: 'Giao diện',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhSinhVienNhanBang),
                                routerLink: ['/trao-bang/config/giao-dien'],
                                heroIcon: 'heroPaintBrush'
                            },
                        ]
                    },
                ]
            },
            {
                items: [
                    {
                        label: 'Tài khoản',
                        styleClass: 'header-label',
                        visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagement),
                        icon:'pi pi-users',
                        expanded: true,
                        items: [
                            {
                                label: 'Người dùng',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagementUser),
                                icon: 'pi pi-user',
                                routerLink: ['/user-management/user']
                            },
                            {
                                label: 'Vai trò',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagementRole),
                                icon: 'pi pi-key',
                                routerLink: ['/user-management/role']
                            }
                        ]
                    }
                ],
                visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagement),
            },
        ],


            this.getData();
    }
    getData() {

    }
}
