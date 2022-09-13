import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationIndexPageComponent } from './operation-index-page.component';

describe('OperationIndexPageComponent', () => {
  let component: OperationIndexPageComponent;
  let fixture: ComponentFixture<OperationIndexPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperationIndexPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationIndexPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
