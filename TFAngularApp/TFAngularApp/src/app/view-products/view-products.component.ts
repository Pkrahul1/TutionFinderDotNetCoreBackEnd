import { Component, OnInit } from '@angular/core';
import { IProduct } from '../quickKart-interfaces/products'
import { ICategory } from '../quickKart-interfaces/categories'
import { ProductService } from '../quickKart-services/product-service/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ITution } from '../quickKart-interfaces/tutioon';
import { HttpErrorResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { filter } from 'rxjs/operators';
@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {
  tutions: ITution[];
  //products: IProduct[];
  //showMsg: boolean = false;
  //filteredProducts: IProduct[];
  //filterCategory: ICategory[];
  shwPlaceholder: string
  filteredTution: ITution[]
  email: string
  imgSrc: string;
  status: boolean
  err: string
  noTution: boolean = false
  constructor(private router: Router, private _userService: ProductService, private route: ActivatedRoute) {
  //  this.products = [{ "name": "rahul", "age": 23,"filterId":1 },
  //    { "name": "raushan","age": 20, "filterId": 1 },
  //    { "name": "Samsung Galaxy S4", "age": 2, "filterId": 3 },
  //    { "name": "BMW", "age": 12, "filterId": 2 }]
  //  this.filterCategory = [
  //    { "filterId": 1, "filterName": "person" },
  //    { "filterId": 2, "filterName": "Motor" },
  //    {"filterId":3,"filterName":"Mobile"}]
  }

  ngOnInit(): void {
  //  if (this.products == null)
  //    this.showMsg = true;
  //  this.filteredProducts = this.products
    //  this.imgSrc ="src/app/quickKart-images/signature.jpg"
    this.email = sessionStorage.getItem('username')
    this.filteredTution = this.tutions
    this.shwPlaceholder = "Enter Value"
    this.noTution = true
    if (this.email == null || this.email == undefined) {
      //this.router.navigate(['/login'], { queryParams: { returnUrl: 'view' } });
    }
    else {
      this.getAllTution()
      this.filteredTution = this.tutions
      this.shwPlaceholder = "Enter Value"
    }
  }
  getAllTution() {
    this._userService.getAllTutions().subscribe(
      resPositive => {
        if (this.status) {
          this.tutions = resPositive
          if (this.tutions == null || this.tutions == undefined) {
            this.noTution = true
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

  applyTution() {
    this._userService.ApplyTution(this.email).subscribe(
      resPositive => {
        this.status = resPositive
        if (this.status) {
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
  submitForm(form: NgForm) {
    var filterBy = form.value.filterId.toString().toLowerCase()
    var filterValue = form.value.filterValue.toString().toLowerCase()
    if (filterBy == "all") {
      this.filteredTution = this.tutions
    }
    else if (filterBy == "city") {
      this.filteredTution = this.tutions.filter(t => t.city.toString().toLowerCase() == filterValue)
    }
    else if (filterBy == "createdby") {
      this.filteredTution = this.tutions.filter(t => t.CreaterId.toString().toLowerCase() == filterValue)
    }
  }
  changePlaceholder(value: string) {
    value = value.toLowerCase()
    if (value == "all") {
      this.shwPlaceholder = "Enter Value"
    }
    else if (value == "createdby") {
      this.shwPlaceholder = "Enter name or email of creater"
    }
    else if (value == "city") {
      this.shwPlaceholder="Enter City"
    }
   
  }
  checkAvailibility(value: string) {

    if (value.toString() == "2") {
      this.filteredTution = this.tutions.filter(t =>t.status.toString().toLowerCase() == "available" || t.status.toString().toLowerCase() == "booked")
    }
    else if (value.toString() == "1") {
      this.filteredTution = this.tutions.filter(t => t.status.toString().toLowerCase() == "available")
    }
    else if (value.toString() == "0") {
      this.filteredTution = this.tutions.filter(t => t.status.toString().toLowerCase() == "booked")
    }
  }
  //showFlitered(filterId: string) {
    
  //  if (filterId == "0")
  //    this.filteredProducts = this.products  
  //  else
  //    this.filteredProducts = this.products.filter(fil => fil.filterId.toString() == filterId);
      
  //}
  //addProduct(product: IProduct) {
  //  this.route.navigate(['/update', product.name, product.age]);

  //}
    
  

}
