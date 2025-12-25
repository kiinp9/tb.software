import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SanKhauMain } from './san-khau-main';

describe('SanKhauMain', () => {
  let component: SanKhauMain;
  let fixture: ComponentFixture<SanKhauMain>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SanKhauMain]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SanKhauMain);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
