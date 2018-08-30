import { AccountReceivableModule } from './account-receivable.module';

describe('AccountReceivableModule', () => {
  let accountReceivableModule: AccountReceivableModule;

  beforeEach(() => {
    accountReceivableModule = new AccountReceivableModule();
  });

  it('should create an instance', () => {
    expect(accountReceivableModule).toBeTruthy();
  });
});
