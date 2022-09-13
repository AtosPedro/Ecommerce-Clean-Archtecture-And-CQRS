import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialFormPageComponent } from './material-form-page.component';

describe('MaterialFormPageComponent', () => {
  let component: MaterialFormPageComponent;
  let fixture: ComponentFixture<MaterialFormPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaterialFormPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MaterialFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
