import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTutionComponent } from './view-tution.component';

describe('ViewTutionComponent', () => {
  let component: ViewTutionComponent;
  let fixture: ComponentFixture<ViewTutionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewTutionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
