import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-two-way-binding',
  templateUrl: './two-way-binding.component.html',
  styleUrls: ['./two-way-binding.component.css']
})
export class TwoWayBindingComponent implements OnInit {

  firstName: string;
  lastName: string;
  emailId: string;
  constructor(private route: ActivatedRoute) {

   
  }

  ngOnInit(): void {

    this.firstName = " rahul kumar";
    this.lastName = "singh";
    this.emailId = this.route.snapshot.params['emailId'];

  }

}
