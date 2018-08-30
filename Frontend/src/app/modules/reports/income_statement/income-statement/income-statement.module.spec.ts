import { IncomeStatementModule } from './income-statement.module';

describe('IncomeStatementModule', () => {
  let incomeStatementModule: IncomeStatementModule;

  beforeEach(() => {
    incomeStatementModule = new IncomeStatementModule();
  });

  it('should create an instance', () => {
    expect(incomeStatementModule).toBeTruthy();
  });
});
