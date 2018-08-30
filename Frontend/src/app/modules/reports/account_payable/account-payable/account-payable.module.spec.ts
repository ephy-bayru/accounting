import { AccountPayableModule } from './account-payable.module';

describe('AccountPayableModule', () => {
  let accountPayableModule: AccountPayableModule;

  beforeEach(() => {
    accountPayableModule = new AccountPayableModule();
  });

  it('should create an instance', () => {
    expect(accountPayableModule).toBeTruthy();
  });
});
