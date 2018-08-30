import { TestBed, inject } from '@angular/core/testing';

import { IncomeStatementService } from './income-statement.service';

describe('IncomeStatementService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [IncomeStatementService]
    });
  });

  it('should be created', inject([IncomeStatementService], (service: IncomeStatementService) => {
    expect(service).toBeTruthy();
  }));
});
