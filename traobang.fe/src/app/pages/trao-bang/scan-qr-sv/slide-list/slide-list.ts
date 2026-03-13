import { ISlideItem } from '@/models/traobang/sv-nhan-bang.models';
import { SvNhanBangStatuses } from '@/shared/constants/sv-nhan-bang.constants';
import { SharedImports } from '@/shared/import.shared';
import { Component, input } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';

@Component({
    selector: 'app-slide-list',
    imports: [SharedImports, TableModule, TagModule],
    templateUrl: './slide-list.html',
    styleUrl: './slide-list.scss'
})
export class SlideList {
    slides = input.required<ISlideItem[]>();
    constStatuses = SvNhanBangStatuses;
}
