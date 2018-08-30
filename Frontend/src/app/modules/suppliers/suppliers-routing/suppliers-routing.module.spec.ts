import { SuppliersRoutingModule } from './suppliers-routing.module';

describe('SuppliersRoutingModule', () => {
  let suppliersRoutingModule: SuppliersRoutingModule;

  beforeEach(() => {
    suppliersRoutingModule = new SuppliersRoutingModule();
  });

  it('should create an instance', () => {
    expect(suppliersRoutingModule).toBeTruthy();
  });
});
