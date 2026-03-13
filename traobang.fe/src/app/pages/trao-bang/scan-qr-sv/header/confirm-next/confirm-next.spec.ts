import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmNext } from './confirm-next';

describe('ConfirmNext', () => {
  let component: ConfirmNext;
  let fixture: ComponentFixture<ConfirmNext>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfirmNext]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfirmNext);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
