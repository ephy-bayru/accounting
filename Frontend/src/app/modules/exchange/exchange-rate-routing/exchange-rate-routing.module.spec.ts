import { ExRateRoutingModule } from './exchange-rate-routing.module';

describe('CurrencyRoutingModule', () => {
  let xRateRoutingModule: ExRateRoutingModule;

  beforeEach(() => {
    xRateRoutingModule = new ExRateRoutingModule();
  });

  it('should create an instance', () => {
    expect(ExRateRoutingModule).toBeTruthy();
  });
});
