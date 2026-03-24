import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSlide } from './create-slide';

describe('CreateSlide', () => {
  let component: CreateSlide;
  let fixture: ComponentFixture<CreateSlide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateSlide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateSlide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
