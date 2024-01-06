import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ITeacher } from '../quickKart-interfaces/Teacher';
import { ProductService } from '../quickKart-services/product-service/product.service';

@Component({
  selector: 'app-view-tution',
  templateUrl: './view-tution.component.html',
  styleUrls: ['./view-tution.component.css']
})
export class ViewTutionComponent implements OnInit {
  teachers: ITeacher[]
  email: string
  imgSrc: string;
  status: boolean
  err: string
  noTeacher: boolean = false
  constructor(private router: Router, private _userService: ProductService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    //  if (this.products == null)
    //    this.showMsg = true;
    //  this.filteredProducts = this.products
    //  this.imgSrc ="src/app/quickKart-images/signature.jpg"
    this.email = sessionStorage.getItem('username')
    if (this.email == null || this.email == undefined) {
      this.router.navigate(['/login'], { queryParams: { returnUrl: 'viewTeacher' } });
    }
    else {
      this.getAllTeacher()
    }
  }
  getAllTeacher() {
    this._userService.getAllTeachers().subscribe(
      resPositive => {
        if (this.status) {
          this.teachers = resPositive
          if (this.teachers == null || this.teachers == undefined) {
            this.noTeacher = true
          }
          this.router.navigate(['/home'])
        }
        else {
          alert("Some error occured, please try with different values.");
        }
      },
      (resNegative: HttpErrorResponse) => {
        this.err = resNegative.message
        console.log(this.err);
        alert(this.err);
      }
    )
  }
}
