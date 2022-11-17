import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDescriptionsComponent } from './product-descriptions.component';

describe('ProductDescriptionsComponent', () => {
  let component: ProductDescriptionsComponent;
  let fixture: ComponentFixture<ProductDescriptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDescriptionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDescriptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
