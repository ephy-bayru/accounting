import { ExRateModule } from './exchange_rate.module';

describe('CurrencyModule', () => {
  let xrateModule: ExRateModule;

  beforeEach(() => {
    xrateModule = new ExRateModule();
  });

  it('should create an instance', () => {
    expect(xrateModule).toBeTruthy();
  });
});
