
import { ELoaiSlide } from '@/models/traobang/slide.models';
import { IViewScanQrTienDoSv } from '@/models/traobang/sv-nhan-bang.models';
import { SvNhanBangStatuses } from '@/shared/constants/sv-nhan-bang.constants';
import { SharedImports } from '@/shared/import.shared';
import { Component, computed, input, output } from '@angular/core';
import { TableModule } from "primeng/table";
import { TagModule } from 'primeng/tag';
import { DragDropModule, CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
    selector: 'app-student-list',
    imports: [SharedImports, TableModule, TagModule, DragDropModule],
    templateUrl: './student-list.html',
    styleUrl: './student-list.scss'
})
export class StudentList {
    students = input.required<IViewScanQrTienDoSv[]>();
    highlightLast = input<boolean>(false);
    constStatuses = SvNhanBangStatuses;
    loaiSlide = ELoaiSlide

    studentsList = computed(() => this.students() || []);
    studentsChange = output<any>();

    drop(event: CdkDragDrop<IViewScanQrTienDoSv[]>) {
        const data = [...this.studentsList()];
        const draggedItem = data[event.previousIndex];

        moveItemInArray(data, event.previousIndex, event.currentIndex);

        data.forEach((item, index) => {
            item.orderTienDo = index + 1;
        });
        let dataChange = {
            IdTienDo: draggedItem.id,
            NewOrder: event.currentIndex + 1
        }
        this.studentsChange.emit(dataChange);
    }


    getRowClass(student: IViewScanQrTienDoSv) {
        return {
            'bg-orange-200': student.trangThai === this.constStatuses.DANG_TRAO_BANG,
            '!bg-[#d4ffd1]': student.loaiSlide === this.loaiSlide.TEXT,
            '!bg-[#ffedd5]': student.isSlideDauCuoi
        };
    }
}
