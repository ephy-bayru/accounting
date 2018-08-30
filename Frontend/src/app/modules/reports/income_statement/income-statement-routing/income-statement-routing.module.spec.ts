import { IncomeStatementRoutingModule } from './income-statement-routing.module';

describe('IncomeStatementRoutingModule', () => {
  let incomeStatementRoutingModule: IncomeStatementRoutingModule;

  beforeEach(() => {
    incomeStatementRoutingModule = new IncomeStatementRoutingModule();
  });

  it('should create an instance', () => {
    expect(incomeStatementRoutingModule).toBeTruthy();
  });
});
