import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenQrCode } from './gen-qr-code';

describe('GenQrCode', () => {
  let component: GenQrCode;
  let fixture: ComponentFixture<GenQrCode>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenQrCode]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenQrCode);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
