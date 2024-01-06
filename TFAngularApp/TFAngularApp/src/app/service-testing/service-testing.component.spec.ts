import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceTestingComponent } from './service-testing.component';

describe('ServiceTestingComponent', () => {
  let component: ServiceTestingComponent;
  let fixture: ComponentFixture<ServiceTestingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceTestingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceTestingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
