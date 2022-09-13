import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreFormPageComponent } from './store-form-page.component';

describe('StoreFormPageComponent', () => {
  let component: StoreFormPageComponent;
  let fixture: ComponentFixture<StoreFormPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoreFormPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
