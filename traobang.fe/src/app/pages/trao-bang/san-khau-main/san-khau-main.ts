import { IViewSvDangTraoBang } from '@/models/traobang/sv-nhan-bang.models';
import { TraoBangSvService } from '@/service/sv-nhan-bang.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { TraoBangHubConst } from '@/shared/constants/sv-nhan-bang.constants';
import { Component, inject } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { GiaoDienService } from '@/service/giao-dien.service';
import { IViewGiaoDien } from '@/models/traobang/giao-dien.models';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
    selector: 'app-san-khau-main',
    imports: [],
    templateUrl: './san-khau-main.html',
    styleUrl: './san-khau-main.scss'
})
export class SanKhauMain extends BaseComponent {
    _svTraoBangService = inject(TraoBangSvService);
    _giaoDienService = inject(GiaoDienService);
    private sanitizer = inject(DomSanitizer);
    svDangTrao: IViewSvDangTraoBang = {};
    hubConnection: signalR.HubConnection | undefined;

    giaoDien!: IViewGiaoDien;
    safeHtml!: SafeHtml;

    override ngOnInit(): void {
        this.getSvDangTrao();
        this.connectHub();
        this.getGiaoDien();
    }

    getSvDangTrao() {
        this._svTraoBangService.getSvDangTraoBang().subscribe({
            next: res => {
                if (this.isResponseSucceed(res)) {
                    this.svDangTrao = res.data;
                    this.renderGiaoDien(); // Re-render with new data
                }
            }
        })
    }

    getGiaoDien() {
        this._giaoDienService.getGiaoDienActive().subscribe({
            next: (res) => {
                if (this.isResponseSucceed(res, false)) {
                    this.giaoDien = res.data;
                    this.renderGiaoDien();
                }
            }
        });
    }

    renderGiaoDien() {
        if (!this.giaoDien) return;

        // Render HTML with template replacement
        if (this.giaoDien.html) {
            let processedHtml = this.giaoDien.html;

            // Replace all {{...}} patterns, handling HTML tags inside
            processedHtml = processedHtml.replace(/\{\{([^}]+)\}\}/g, (match, content) => {
                // Remove all HTML tags to get the variable name
                const key = content.replace(/<[^>]*>/g, '').trim();
                const value = (this.svDangTrao as any)[key] || '';

                // Replace variable name with value while keeping HTML tags
                return content.replace(key, value);
            });

            this.safeHtml = this.sanitizer.bypassSecurityTrustHtml(processedHtml);
        }

        // Render CSS
        if (this.giaoDien.css) {
            const styleId = 'giao-dien-style';
            let styleElement = document.getElementById(styleId) as HTMLStyleElement;

            if (!styleElement) {
                styleElement = document.createElement('style');
                styleElement.id = styleId;
                document.head.appendChild(styleElement);
            }

            styleElement.innerHTML = this.giaoDien.css;
        }

        // Render JS
        if (this.giaoDien.js) {
            setTimeout(() => {
                try {
                    const scriptFunction = new Function(this.giaoDien.js!);
                    scriptFunction();
                } catch (error) {
                    console.error('Error executing giao dien script:', error);
                }
            }, 100);
        }
    }

    connectHub() {
        const hubUrl = TraoBangHubConst.HUB;
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl, {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets,
            })
            .build();

        this.hubConnection.on(TraoBangHubConst.ReceiveSinhVienDangTrao, (...args) => {
            //const idSubPlan = args[0];

            //if (!idSubPlan) return;

            this.getSvDangTrao();
            // this.initData();
        });

        this.hubConnection.on(TraoBangHubConst.ReceiveChonKhoa, (...args) => {
            //const idSubPlan = args[0];

            //if (!idSubPlan) return;

            this.getSvDangTrao();
            // this.initData();
        });

        this.hubConnection.start().then();
    }

    ngOnDestroy(): void {
        this.hubConnection?.stop().then();

        // Remove dynamic style
        const styleElement = document.getElementById('giao-dien-style');
        if (styleElement) {
            styleElement.remove();
        }
    }
}
