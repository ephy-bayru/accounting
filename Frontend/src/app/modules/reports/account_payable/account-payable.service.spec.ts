import { TestBed, inject } from '@angular/core/testing';

import { AccountPayableService } from './account-payable.service';

describe('AccountPayableService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccountPayableService]
    });
  });

  it('should be created', inject([AccountPayableService], (service: AccountPayableService) => {
    expect(service).toBeTruthy();
  }));
});
