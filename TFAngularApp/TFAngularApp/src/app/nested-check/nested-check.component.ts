import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-nested-check',
  templateUrl: './nested-check.component.html',
  styleUrls: ['./nested-check.component.css']
})
export class NestedCheckComponent implements OnInit {
  courses = [{ "courseName": 'Angular', "courseId": 1 },
    { "courseName": 'React', "courseId": 2 }]
  course: any[];
  check = false;
  color: string;
  constructor() { }

  ngOnInit(): void {
  }
  @Input() set cName(name: string) {
    this.course = [];
    for (let i = 0; i < this.courses.length; i++) {
      if (name == this.courses[i].courseName) { 
        this.course.push(this.courses[i])
        this.check = true
      }
    }


  }
  @Output() onRegister = new EventEmitter<string>();

  register(courseName: string) {
    this.onRegister.emit(courseName)
    this.color = "red";
  }

}
