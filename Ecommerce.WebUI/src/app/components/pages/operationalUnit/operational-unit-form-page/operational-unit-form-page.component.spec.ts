import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationalUnitFormPageComponent } from './operational-unit-form-page.component';

describe('OperationalUnitFormPageComponent', () => {
  let component: OperationalUnitFormPageComponent;
  let fixture: ComponentFixture<OperationalUnitFormPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperationalUnitFormPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationalUnitFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
