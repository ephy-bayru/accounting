import { TestBed, inject } from '@angular/core/testing';

import { AccountReceivableService } from './account-receivable.service';

describe('AccountReceivableService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccountReceivableService]
    });
  });

  it('should be created', inject([AccountReceivableService], (service: AccountReceivableService) => {
    expect(service).toBeTruthy();
  }));
});
