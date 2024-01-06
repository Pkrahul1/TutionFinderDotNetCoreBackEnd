import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from '../quickKart-services/product-service/product.service';
import { take } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  status: boolean = false;
  err: string;
  fullName: string;
  isEmailRegistered: boolean;
  showMsg: boolean;

  constructor(private router: Router, private _userService: ProductService)
  {

  }

  ngOnInit(): void {
  }
  submitForm(form: NgForm) {

    //console.log(form.value.email);
    //console.log(form.value.password)
    //console.log(form.value.cpassword);
    //console.log(form.value.age)
    //console.log(form.value.mobileNo)
    //console.log(form.value.gender)
    //sessionStorage.setItem('username', form.value.email)
    var email = form.value.email;
    var name = form.value.fullName;
    var city = form.value.city;
    var password = form.value.password;
    this._userService.registerUser(email,name,password,city).subscribe(
      resPositive => {
        this.status = resPositive;
        if (this.status) {
          alert("Registered successfully for:" + this.fullName);
          
        }
        else {
          alert("Some error occured, please try with different values.");
        }
      },
      resNegative => {
        this.err = resNegative
        //console.log(this.err);
        alert(this.err);
      }
    )
    console.log(this.status,"registration status");
    //alert("registered successfuly");
    this.router.navigate(['/html'])

  }
  checkEmail(email: string) {
    console.log(email)
    this._userService.CheckEmail(email).subscribe(
      resPositive => {
        this.status = resPositive;
        if (this.status == false) {
          this.isEmailRegistered = true
          this.showMsg = true
          console.log(this.isEmailRegistered)
        }
      },
      (resNegative: HttpErrorResponse) => {
        this.err = resNegative.message
        this.isEmailRegistered = false
        //console.log(this.err);
        alert(this.err);
      }
    )
  }
}
