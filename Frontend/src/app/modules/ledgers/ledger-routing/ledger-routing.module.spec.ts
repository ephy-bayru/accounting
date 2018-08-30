import { LedgerRoutingModule } from './ledger-routing.module';

describe('LedgerRoutingModule', () => {
  let ledgerRoutingModule: LedgerRoutingModule;

  beforeEach(() => {
    ledgerRoutingModule = new LedgerRoutingModule();
  });

  it('should create an instance', () => {
    expect(ledgerRoutingModule).toBeTruthy();
  });
});
