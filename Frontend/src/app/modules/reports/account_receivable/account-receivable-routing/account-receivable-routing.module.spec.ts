import { AccountReceivableRoutingModule } from './account-receivable-routing.module';

describe('AccountReceivableRoutingModule', () => {
  let accountReceivableRoutingModule: AccountReceivableRoutingModule;

  beforeEach(() => {
    accountReceivableRoutingModule = new AccountReceivableRoutingModule();
  });

  it('should create an instance', () => {
    expect(accountReceivableRoutingModule).toBeTruthy();
  });
});
