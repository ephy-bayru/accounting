import { TrialBalanceModule } from './trial-balance.module';

describe('TrialBalanceModule', () => {
  let trialBalanceModule: TrialBalanceModule;

  beforeEach(() => {
    trialBalanceModule = new TrialBalanceModule();
  });

  it('should create an instance', () => {
    expect(trialBalanceModule).toBeTruthy();
  });
});
