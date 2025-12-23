import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiaoDien } from './giao-dien';

describe('GiaoDien', () => {
  let component: GiaoDien;
  let fixture: ComponentFixture<GiaoDien>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GiaoDien]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GiaoDien);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
