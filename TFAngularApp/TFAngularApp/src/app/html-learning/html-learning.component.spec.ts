import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HtmlLearningComponent } from './html-learning.component';

describe('HtmlLearningComponent', () => {
  let component: HtmlLearningComponent;
  let fixture: ComponentFixture<HtmlLearningComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HtmlLearningComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HtmlLearningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
