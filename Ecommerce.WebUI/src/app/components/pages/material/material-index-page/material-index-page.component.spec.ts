import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialIndexPageComponent } from './material-index-page.component';

describe('MaterialIndexPageComponent', () => {
  let component: MaterialIndexPageComponent;
  let fixture: ComponentFixture<MaterialIndexPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaterialIndexPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MaterialIndexPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
