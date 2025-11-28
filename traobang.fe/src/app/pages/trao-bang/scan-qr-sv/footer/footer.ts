
import { IViewScanQrCurrentSubPlan } from '@/models/traobang/sv-nhan-bang.models';
import { Component, input } from '@angular/core';

@Component({
  selector: 'app-footer',
  imports: [],
  templateUrl: './footer.html'
})
export class Footer {
  data = input.required<IViewScanQrCurrentSubPlan | null | undefined>();
}
