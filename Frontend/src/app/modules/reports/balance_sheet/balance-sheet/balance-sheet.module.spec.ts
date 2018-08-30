import { BalanceSheetModule } from './balance-sheet.module';

describe('BalanceSheetModule', () => {
  let balanceSheetModule: BalanceSheetModule;

  beforeEach(() => {
    balanceSheetModule = new BalanceSheetModule();
  });

  it('should create an instance', () => {
    expect(balanceSheetModule).toBeTruthy();
  });
});
