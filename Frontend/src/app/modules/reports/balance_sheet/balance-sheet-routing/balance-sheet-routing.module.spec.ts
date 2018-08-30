import { BalanceSheetRoutingModule } from './balance-sheet-routing.module';

describe('BalanceSheetRoutingModule', () => {
  let balanceSheetRoutingModule: BalanceSheetRoutingModule;

  beforeEach(() => {
    balanceSheetRoutingModule = new BalanceSheetRoutingModule();
  });

  it('should create an instance', () => {
    expect(balanceSheetRoutingModule).toBeTruthy();
  });
});
