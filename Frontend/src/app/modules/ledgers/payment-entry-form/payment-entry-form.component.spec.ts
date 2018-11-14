import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentEntryFormComponent } from './payment-entry-form.component';

describe('PaymentEntryFormComponent', () => {
  let component: PaymentEntryFormComponent;
  let fixture: ComponentFixture<PaymentEntryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentEntryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentEntryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
