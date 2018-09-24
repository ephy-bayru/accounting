import { TestBed, inject } from '@angular/core/testing';

import { SmartAppConfigService } from './smart-app-config.service';

describe('SmartAppConfigService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SmartAppConfigService]
    });
  });

  it('should be created', inject([SmartAppConfigService], (service: SmartAppConfigService) => {
    expect(service).toBeTruthy();
  }));
});
