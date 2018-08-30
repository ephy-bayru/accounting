import { CurrencyRoutingModule } from './currency-routing.module';

describe('CurrencyRoutingModule', () => {
  let currencyRoutingModule: CurrencyRoutingModule;

  beforeEach(() => {
    currencyRoutingModule = new CurrencyRoutingModule();
  });

  it('should create an instance', () => {
    expect(currencyRoutingModule).toBeTruthy();
  });
});
