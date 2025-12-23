import { SharedImports } from '@/shared/import.shared';
import { GiaoDienService } from '@/service/giao-dien.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import createStudioEditor from '@grapesjs/studio-sdk';
import { tableComponent, dialogComponent, rteTinyMce, canvasAbsoluteMode, layoutSidebarButtons, googleFontsAssetProvider, dataSourceHandlebars, } from "@grapesjs/studio-sdk-plugins";
import { Breadcrumb } from '@/shared/components/breadcrumb/breadcrumb';
import { MenuItem } from 'primeng/api';
import { IViewGiaoDien } from '@/models/traobang/giao-dien.models';
@Component({
    selector: 'app-create-giao-dien',
    imports: [SharedImports, Breadcrumb],
    templateUrl: './create-giao-dien.html',
    styleUrl: './create-giao-dien.scss'
})
export class CreateGiaoDien extends BaseComponent {
    @ViewChild('editorEl', { static: true }) editorEl!: ElementRef;
    editor: any;
    private _giaoDienServices = inject(GiaoDienService);

    items: MenuItem[] = [{ label: 'Danh sách giao diện', routerLink: 'trao-bang/config/giao-dien' }, { label: 'Giao diện' }];
    home: MenuItem = { icon: 'pi pi-home', routerLink: '/' };

    idGiaoDien!: any;
    giaoDien!: IViewGiaoDien
    submitted: boolean = false;

    override form: FormGroup = new FormGroup({
        tenGiaoDien: new FormControl(null, [Validators.required])
    });

    override ValidationMessages: Record<string, Record<string, string>> = {
        tenGiaoDien: {
            required: 'Không được bỏ trống'
        },
    };


    async ngAfterViewInit() {
        await createStudioEditor({
            licenseKey: '25678fc14abc44f1824d13156e1b355f53988497d8354604a7cb3176a076c8e',
            root: this.editorEl.nativeElement,
            fonts: {
                enableFontManager: true,
            },
            onReady: ({ editor }) => {
                this.editor = editor;
                if (this.idGiaoDien) {

                    editor.loadData(this.stringToDesign(this.giaoDien.noiDung ?? ""))
                }
                console.log('EDITOR READY', this.editor);
            },
            plugins: [
                (editor) => {
                    // editor.Blocks.add('variable', {
                    //     label: "name",
                    //     content: `<H1>{{name}}<H1/>`,
                    //     category: 'Data',
                    // })
                },
                tableComponent.init({
                    block: { category: 'Extra', label: 'My Table' }
                }),
                rteTinyMce.init({
                    enableOnClick: true,
                    loadConfig: ({ component, config }) => {
                        const demoRte = component.get('demorte');
                        if (demoRte === 'fixed') {
                            return {
                                toolbar:
                                    'bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | link image media',
                                fixed_toolbar_container_target: document.querySelector('.rteContainer')
                            };
                        } else if (demoRte === 'quickbar') {
                            return {
                                plugins: `${config.plugins} quickbars`,
                                toolbar: false,
                                quickbars_selection_toolbar: 'bold italic underline strikethrough | quicklink image'
                            };
                        }
                        return {};
                    }
                }),
                // canvasAbsoluteMode,
                layoutSidebarButtons,
            ],
            blocks: {

            },
            // dataSources: {
            //     globalData: {
            //         user: { firstName: 'Alice', isCustomer: true },
            //         products: [
            //             { name: 'Laptop Pro X15', price: 1200.0 },
            //             { name: 'Wireless Mouse M2', price: 25.99 }
            //         ]
            //     },
            // },
            layout: {
                default: {
                    type: 'row',
                    style: { height: '100%' },
                    children: [
                        { type: 'sidebarLeft' },
                        {
                            type: 'canvasSidebarTop',
                            sidebarTop: {
                                rightContainer: {
                                    buttons: ({ items }) => [{
                                        ...items.find(item => item.id === 'showCode'),
                                        id: items.find(item => item.id === 'showCode')?.id || 'showCode',
                                        variant: 'outline',
                                        label: 'Show code'
                                    }],
                                },
                            },
                        },
                        { type: 'sidebarRight' },
                    ],
                },
            },
            project: {
                default: {
                    pages: [
                        {
                            name: 'Demo',
                            component: `
                            <h1>Tạo Giao Diện</h1>
                           `
                        },
                    ],
                },
            },
        });

    }

    override ngOnInit() {
        if (!this.idGiaoDien) {
            this._activatedRoute.queryParamMap.subscribe((params) => {
                const id = params.get('id');
                if (id) {
                    this.idGiaoDien = id;
                }
            });
        }
        this.getGiaoDienById()
    }

    getGiaoDienById() {
        if (this.idGiaoDien) {
            this.loading = true;
            this._giaoDienServices.getById(this.idGiaoDien).subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, false)) {
                        this.giaoDien = res.data;
                        this.form.get('tenGiaoDien')?.patchValue(this.giaoDien.tenGiaoDien);
                    }
                }
            });
        }

    }

    saveTemplate() {
        if (this.isFormInvalid()) {
            this.submitted = true;
            return;
        }
        this.loading = true;
        const projectData = this.editor.storeData();
        let body: any
        if (this.idGiaoDien) {
            body = {
                id: this.idGiaoDien,
                tenGiaoDien: this.form.get("tenGiaoDien")?.value,
                noiDung: this.designToString(projectData)
            }
        }
        else {
            body = {
                tenGiaoDien: this.form.get("tenGiaoDien")?.value,
                noiDung: this.designToString(projectData)
            }
        }

        if (this.idGiaoDien) {
            this._giaoDienServices.update(body).subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, true, "Cập nhật giao diện thành công")) {
                        this.ngOnInit()
                    }
                },
                error: (err) => {
                    this.messageError(err?.message);
                },
                complete: () => {
                    this.loading = false;
                }
            })
        }
        else {
            this._giaoDienServices.create(body).subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, true, "Thêm mới giao diện thành công")) {
                        this.idGiaoDien = res.data.id
                        this.ngOnInit()
                    }

                },
                error: (err) => {
                    this.messageError(err?.message);
                },
                complete: () => {
                    this.loading = false;
                }
            })
        }
    }

    back() {
        this.router.navigate(['trao-bang/config/giao-dien']);
    }

    designToString(design: any): string {
        return JSON.stringify(design);
    }

    stringToDesign(designString: string): any {
        try {
            return JSON.parse(designString);
        } catch (error) {
            console.error("Invalid design JSON string:", error);
            return null;
        }
    }
}

