import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGiaoDien } from './create-giao-dien';

describe('CreateGiaoDien', () => {
  let component: CreateGiaoDien;
  let fixture: ComponentFixture<CreateGiaoDien>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateGiaoDien]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateGiaoDien);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
