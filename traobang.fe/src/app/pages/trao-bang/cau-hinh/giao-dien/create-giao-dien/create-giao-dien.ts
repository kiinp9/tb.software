import { SharedImports } from '@/shared/import.shared';
import { GiaoDienService } from '@/service/giao-dien.service';
import { BaseComponent } from '@/shared/components/base/base-component';
import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import createStudioEditor from '@grapesjs/studio-sdk';
import { tableComponent, dialogComponent, rteTinyMce, canvasAbsoluteMode, layoutSidebarButtons, googleFontsAssetProvider, dataSourceHandlebars } from '@grapesjs/studio-sdk-plugins';
import { Breadcrumb } from '@/shared/components/breadcrumb/breadcrumb';
import { MenuItem } from 'primeng/api';
import { IViewGiaoDien } from '@/models/traobang/giao-dien.models';
import { environment } from 'src/environments/environment';
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
    giaoDien!: IViewGiaoDien;
    submitted: boolean = false;
    isPlan: any = false;
    override form: FormGroup = new FormGroup({
        tenGiaoDien: new FormControl(null, [Validators.required])
    });

    override ValidationMessages: Record<string, Record<string, string>> = {
        tenGiaoDien: {
            required: 'Không được bỏ trống'
        }
    };

    async ngAfterViewInit() {
        await createStudioEditor({
            // licenseKey: '25678fc14abc44f1824d13156e1b355f53988497d8354604a7cb3176a076c8e',
            licenseKey: environment.grapeJsLicense,
            root: this.editorEl.nativeElement,
            fonts: {
                enableFontManager: true
            },
            onReady: ({ editor }) => {
                this.editor = editor;
                this.loadEditorData();
                console.log('EDITOR READY', this.editor);
            },
            plugins: [
                googleFontsAssetProvider.init({ apiKey: 'AIzaSyByNrR2JpnJcuRRQimwgRhHDca8fXIHx8Y' }),
                (editor) => {
                    editor.Blocks.add('variable1', {
                        label: "Cấp bằng",
                        content: `<span>{{capBang}}<span/>`,
                        category: 'Data',
                    }),
                        editor.Blocks.add('variable2', {
                            label: "Họ và tên",
                            content: `<span>{{hoVaTen}}<span/>`,
                            category: 'Data',
                        }),
                        editor.Blocks.add('variable3', {
                            label: "Tên ngành đào tạo",
                            content: `<span>{{tenNganhDaoTao}}<span/>`,
                            category: 'Data',
                        }),
                        editor.Blocks.add('variable4', {
                            label: "Thành tích",
                            content: `<span>{{thanhTich}}<span/>`,
                            category: 'Data',
                        }),
                        editor.Blocks.add('variable5', {
                            label: "Xếp hạng",
                            content: `<span>{{texepHangxt}}<span/>`,
                            category: 'Data',
                        }),
                        editor.Blocks.add('variable6', {
                            label: "Text",
                            content: `<span>{{text}}<span/>`,
                            category: 'Data',
                        }),
                        editor.onReady(() => {
                            const textCmp = editor.getWrapper()?.find('p')[0];
                            editor.select(textCmp);
                        });
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
                                toolbar: 'bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | link image media',
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
                layoutSidebarButtons
            ],
            blocks: {},
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
                                    buttons: ({ items }) => [
                                        {
                                            ...items.find((item) => item.id === 'showCode'),
                                            id: items.find((item) => item.id === 'showCode')?.id || 'showCode',
                                            variant: 'outline',
                                            label: 'Show code'
                                        }
                                    ]
                                }
                            }
                        },
                        { type: 'sidebarRight' }
                    ]
                }
            },
            project: {
                default: {
                    pages: [
                        {
                            name: 'Demo',
                            component: `
                            <h1>Tạo Giao Diện</h1>
                           `
                        }
                    ]
                }
            }
        });
    }

    override ngOnInit() {
        if (!this.idGiaoDien) {
            this._activatedRoute.queryParamMap.subscribe((params) => {
                const id = params.get('id');
                this.isPlan = params.get('isPlan');
                if (id) {
                    this.idGiaoDien = id;
                }
            });
        }
        this.getGiaoDienById();
    }

    getGiaoDienById() {
        if (this.idGiaoDien) {
            this.loading = true;
            this._giaoDienServices.getById(this.idGiaoDien).subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, false)) {
                        this.giaoDien = res.data;
                        this.form.get('tenGiaoDien')?.patchValue(this.giaoDien.tenGiaoDien);
                        this.loadEditorData();
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
        let body: any;
        if (this.idGiaoDien) {
            body = {
                id: this.idGiaoDien,
                tenGiaoDien: this.form.get('tenGiaoDien')?.value,
                noiDung: this.designToString(projectData),
                html: this.editor.getHtml(),
                css: this.editor.getCss(),
                js: this.editor.getJs()
            };
        } else {
            body = {
                tenGiaoDien: this.form.get('tenGiaoDien')?.value,
                noiDung: this.designToString(projectData),
                html: this.editor.getHtml(),
                css: this.editor.getCss(),
                js: this.editor.getJs()
            };
        }

        if (this.idGiaoDien) {
            this._giaoDienServices.update(body).subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, true, 'Cập nhật giao diện thành công')) {
                        this.ngOnInit();
                    }
                },
                error: (err) => {
                    this.messageError(err?.message);
                },
                complete: () => {
                    this.loading = false;
                }
            });
        } else {
            this._giaoDienServices.create(body).subscribe({
                next: (res) => {
                    if (this.isResponseSucceed(res, true, 'Thêm mới giao diện thành công')) {
                        this.idGiaoDien = res.data.id;
                        this.ngOnInit();
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

    back() {
        if (this.isPlan) {
            this.router.navigate(['trao-bang/config/plan']);
        }
        else {
            this.router.navigate(['trao-bang/config/giao-dien']);
        }
    }

    loadEditorData() {
        if (!this.editor) return;

        this.editor.loadData({
            pages: [],
            styles: [],
            components: []
        });

        if (this.idGiaoDien && this.giaoDien?.noiDung) {
            const designData = this.stringToDesign(this.giaoDien.noiDung);
            if (designData) {
                this.editor.loadData(designData);
            }
        }
    }

    designToString(design: any): string {
        return JSON.stringify(design);
    }

    stringToDesign(designString: string): any {
        try {
            return JSON.parse(designString);
        } catch (error) {
            console.error('Invalid design JSON string:', error);
            return null;
        }
    }
}
