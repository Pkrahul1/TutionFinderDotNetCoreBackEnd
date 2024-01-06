import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
//  template: `
//<h1>Welcome on Home </h1>
//<h2>Click above options</h2>
//`,
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  value: string;
  constructor() { }

  ngOnInit(): void {
  }
  changingValue(val:string) {
    alert('done')
  }

}
