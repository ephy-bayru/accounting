import { BanksRoutingModule } from './banks-routing.module';

describe('BanksRoutingModule', () => {
  let banksRoutingModule: BanksRoutingModule;

  beforeEach(() => {
    banksRoutingModule = new BanksRoutingModule();
  });

  it('should create an instance', () => {
    expect(banksRoutingModule).toBeTruthy();
  });
});
