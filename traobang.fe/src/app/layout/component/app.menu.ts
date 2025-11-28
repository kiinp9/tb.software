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
            // {
            //     items:[
            //         {
            //             label: 'Dashboard',
            //             routerLink: ['/']
            //         }
            //     ]
            // },
           
            
            {
                items: [
                    {
                        label: 'Trao bằng',
                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBang),
                        items: [
                            {
                                label: 'Màn hình',
                                items: [
                                    {
                                        label: 'Sân khấu',
                                        routerLink: ['/guest/trao-bang/main-screen'],
                                        visible: true,
                                    },
                                    {
                                        label: 'Cánh gà',
                                        routerLink: ['/guest/trao-bang/side-screen'],
                                        visible: true,
                                    },
                                    {
                                        label: 'Điều khiển',
                                        routerLink: ['/trao-bang/mc-screen'],
                                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangMc),
                                    },
                                    {
                                        label: 'Checkin',
                                        routerLink: ['/trao-bang/scan-qr-sv'],
                                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangQuetQr),
                                    },
                                ]
                            },
                            {
                                label: 'Cấu hình',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinh),
                                items: [
                                    {
                                        label: 'Chương trình',
                                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhChuongTrinh),
                                        routerLink: ['/trao-bang/config/plan']
                                    },
                                    {
                                        label: 'Khoa',
                                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhKhoa),
                                        routerLink: ['/trao-bang/config/sub-plan']
                                    },
                                    {
                                        label: 'SV nhận bằng',
                                        visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBangCauHinhSinhVienNhanBang),
                                        routerLink: ['/trao-bang/config/sv']
                                    },
                                ]
                            },
                        ]
                    }
                ],
                visible: this._sharedService.isGranted(PermissionConstants.MenuTraoBang),
            },
            {
                items: [
                    {
                        label: 'QL Tài khoản',
                        visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagement),
                        items: [
                            {
                                label: 'Người dùng',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagementUser),
                                heroIcon: 'heroUser',
                                routerLink: ['/user-management/user']
                            },
                            {
                                label: 'Vai trò',
                                visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagementRole),
                                heroIcon: 'heroUserGroup',
                                routerLink: ['/user-management/role']
                            }
                        ]
                    }
                ],
                visible: this._sharedService.isGranted(PermissionConstants.MenuUserManagement),
            },
            // {
            //     items: [
            //         {
            //             label: 'MS Teams',
            //             items: [
            //                 { label: 'Họp trực tuyến', heroIcon: 'heroRadio', routerLink: ['/meeting/hop-truc-tuyen'] },
            //             ]
            //         }
            //     ]
            // },
            // {
            //     items: [
            //         {
            //             label: 'Tài khoản',
            //             routerLink: ['/contacts']
            //         }
            //     ]
            // },
            // {
            //     items: [
            //         {
            //             label: 'Audit log',
            //             routerLink: ['/contacts']
            //         }
            //     ]
            // },

        ];
        this.getData();
    }
    getData() {
       
    }
}