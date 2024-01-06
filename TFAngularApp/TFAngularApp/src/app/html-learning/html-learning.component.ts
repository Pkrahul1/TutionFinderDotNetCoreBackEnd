import { Component, OnInit } from '@angular/core';
import { ProductService } from '../quickKart-services/product-service/product.service';
import { Router } from '@angular/router';
import { IUser } from '../quickKart-interfaces/user';
import { ITestUser } from '../quickKart-interfaces/TestUser';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-html-learning',
  templateUrl: './html-learning.component.html',
  styleUrls: ['./html-learning.component.css']
})
export class HtmlLearningComponent implements OnInit {
  //users: IUser[];
  testusers: ITestUser[];
  returnUrl: string = null;
  constructor(private _user: ProductService, private router: Router) { }

  ngOnInit(): void {
    this._user.getallStudent().subscribe(
      res => {
        this.testusers = res;
        console.log(this.testusers)
      },
      (resNegative: HttpErrorResponse) => {
        this.testusers = null;
        this.returnUrl = resNegative.url.split("ReturnUrl=")[1]
        if (this.returnUrl) {
          this.router.navigate(['/login'], { queryParams: { returnUrl: this.returnUrl } });
        }
        console.log(this.returnUrl)
      },
      ()=>console.log(this.testusers)
    )
    
  }

}
