import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalanderFormComponent } from './calander-form.component';

describe('CalanderFormComponent', () => {
  let component: CalanderFormComponent;
  let fixture: ComponentFixture<CalanderFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalanderFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalanderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
