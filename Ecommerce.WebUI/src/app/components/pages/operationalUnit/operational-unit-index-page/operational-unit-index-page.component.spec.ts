import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationalUnitIndexPageComponent } from './operational-unit-index-page.component';

describe('OperationalUnitIndexPageComponent', () => {
  let component: OperationalUnitIndexPageComponent;
  let fixture: ComponentFixture<OperationalUnitIndexPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperationalUnitIndexPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationalUnitIndexPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
