import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlideList } from './slide-list';

describe('SlideList', () => {
  let component: SlideList;
  let fixture: ComponentFixture<SlideList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SlideList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SlideList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
