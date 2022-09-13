import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreIndexPageComponent } from './store-index-page.component';

describe('StoreIndexPageComponent', () => {
  let component: StoreIndexPageComponent;
  let fixture: ComponentFixture<StoreIndexPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoreIndexPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreIndexPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
