import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationFormPageComponent } from './operation-form-page.component';

describe('OperationFormPageComponent', () => {
  let component: OperationFormPageComponent;
  let fixture: ComponentFixture<OperationFormPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperationFormPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
