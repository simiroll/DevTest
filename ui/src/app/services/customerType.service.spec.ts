import { TestBed } from '@angular/core/testing';

import { CustomerTypeService } from './customerType.service';

describe('CustomerTypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CustomerTypeService = TestBed.get(CustomerTypeService);
    expect(service).toBeTruthy();
  });
});
