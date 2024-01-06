import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'QuickKartApp';
  name: string;
  msg: string='';

  coursereg(courseNme: string) {
    this.msg = `registration for course ${courseNme} is successful`
  }
}
