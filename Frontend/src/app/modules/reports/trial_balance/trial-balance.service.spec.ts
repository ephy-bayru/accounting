import { TestBed, inject } from '@angular/core/testing';

import { TrialBalanceService } from './trial-balance.service';

describe('TrialBalanceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrialBalanceService]
    });
  });

  it('should be created', inject([TrialBalanceService], (service: TrialBalanceService) => {
    expect(service).toBeTruthy();
  }));
});
