import { Component, OnInit } from '@angular/core';
import { ProductService } from '../quickKart-services/product-service/product.service';
import { IProduct } from '../quickKart-interfaces/products';
import { ICategory } from '../quickKart-interfaces/categories';
import { Router } from '@angular/router';

@Component({
  selector: 'app-service-testing',
  templateUrl: './service-testing.component.html',
  styleUrls: ['./service-testing.component.css']
})
export class ServiceTestingComponent implements OnInit {
  products: IProduct[];
  categories: ICategory[];
  email: string;
  constructor(private _productService: ProductService, private router: Router) {
    this.email = sessionStorage.getItem('username');
}

  ngOnInit(): void {
    this.products = this._productService.getProducts();
    this.categories = this._productService.getCategory();
    alert("service is working now check two way binding")
    this.router.navigate(['/twoWay', this.email])

  }
}
