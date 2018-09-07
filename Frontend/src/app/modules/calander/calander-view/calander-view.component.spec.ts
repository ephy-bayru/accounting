import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalanderViewComponent } from './calander-view.component';

describe('CalanderViewComponent', () => {
  let component: CalanderViewComponent;
  let fixture: ComponentFixture<CalanderViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalanderViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalanderViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
