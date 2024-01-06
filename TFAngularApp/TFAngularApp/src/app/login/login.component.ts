import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProductService } from '../quickKart-services/product-service/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  status: boolean;
  err: string;
  returnUrl: string;
  isEmailExisting: boolean;
  showMsg: boolean = false;
  constructor(private router: Router, private _userService: ProductService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.params["ReturnUrl"]
    //alert("inside ngloin")
    console.log("inside login ngoniit")
  }
  submitForm(form: NgForm) {
    
    console.log(form.value.email);
    console.log(form.value.password)
    var email = form.value.email
    var password = form.value.password
    //this.returnUrl = this.route.snapshot.params["ReturnUrl"]
    this._userService.Login(email,password).subscribe(
      resPositive => {
        this.status = resPositive;
        if (this.status) {
          this.isEmailExisting = true
          sessionStorage.setItem('username', form.value.email)
          alert("LoggedIn successfully for:" + email);
          console.log(this.status)
        }
        else {
          this.isEmailExisting = false
          alert("Some error occured, please try with different values.");
        }
      },
      (resNegative: HttpErrorResponse) => {
        this.err = resNegative.message
        this.isEmailExisting = false
        //console.log(this.err);
        alert(this.err);
      }
    )
    console.log(this.status,"Login status");
    //alert("registered successfuly");
    //this.router.navigate(['/html'])

    
    alert("loged in successfuly");
    //this.router.navigate(['/home'])
  }
}
