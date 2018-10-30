import { TestBed, inject } from '@angular/core/testing';
import { ExchangeRateService } from './exchange_rate.service';

describe('CurrencyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ExchangeRateService]
    });
  });

  it('should be created', inject([ExchangeRateService], (service: ExchangeRateService) => {
    expect(service).toBeTruthy();
  }));
});
