import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NestedCheckComponent } from './nested-check.component';

describe('NestedCheckComponent', () => {
  let component: NestedCheckComponent;
  let fixture: ComponentFixture<NestedCheckComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NestedCheckComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NestedCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
