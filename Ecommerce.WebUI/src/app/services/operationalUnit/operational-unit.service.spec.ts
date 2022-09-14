import { TestBed } from '@angular/core/testing';

import { OperationalUnitService } from './operational-unit.service';

describe('OperationalUnitService', () => {
  let service: OperationalUnitService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OperationalUnitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
