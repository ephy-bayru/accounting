import { AccountPayableRoutingModule } from './account-payable-routing.module';

describe('AccountPayableRoutingModule', () => {
  let accountPayableRoutingModule: AccountPayableRoutingModule;

  beforeEach(() => {
    accountPayableRoutingModule = new AccountPayableRoutingModule();
  });

  it('should create an instance', () => {
    expect(accountPayableRoutingModule).toBeTruthy();
  });
});
