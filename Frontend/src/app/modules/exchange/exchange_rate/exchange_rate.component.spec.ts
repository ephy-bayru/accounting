import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExchangerateComponent } from './exchange_rate.component';

describe('CurrencyComponent', () => {
  let component: ExchangerateComponent;
  let fixture: ComponentFixture<ExchangerateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExchangerateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExchangerateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

});
