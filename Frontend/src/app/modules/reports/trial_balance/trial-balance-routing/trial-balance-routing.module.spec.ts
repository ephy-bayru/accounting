import { TrialBalanceRoutingModule } from './trial-balance-routing.module';

describe('TrialBalanceRoutingModule', () => {
  let trialBalanceRoutingModule: TrialBalanceRoutingModule;

  beforeEach(() => {
    trialBalanceRoutingModule = new TrialBalanceRoutingModule();
  });

  it('should create an instance', () => {
    expect(trialBalanceRoutingModule).toBeTruthy();
  });
});
