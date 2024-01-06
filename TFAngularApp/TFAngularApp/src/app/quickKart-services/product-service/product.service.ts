import { Injectable } from '@angular/core';
import { IProduct } from '../../quickKart-interfaces/products'
import { ICategory } from '../../quickKart-interfaces/categories'
import {  IUser } from '../../quickKart-interfaces/user'
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ILogin } from '../../quickKart-interfaces/Login';
import { ITestUser } from '../../quickKart-interfaces/TestUser';
import { IRegister } from '../../quickKart-interfaces/Register';
import { ITution } from '../../quickKart-interfaces/tutioon';
import { ITeacher } from '../../quickKart-interfaces/Teacher';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  products: IProduct[];
  categories: ICategory[];
  

  constructor(private http: HttpClient) {
   
  }
  getProducts() {
    this.products = [{ "name": "rahul", "age": 23, "filterId": 1 },
    { "name": "raushan", "age": 20, "filterId": 1 },
    { "name": "Samsung Galaxy S4", "age": 2, "filterId": 3 },
      { "name": "BMW", "age": 12, "filterId": 2 }]
    return this.products
  }
  getCategory() {
    this.categories = [
      { "filterId": 1, "filterName": "person" },
      { "filterId": 2, "filterName": "Motor" },
      { "filterId": 3, "filterName": "Mobile" }]
    return this.categories
  }
  registerUser(email: string, name: string, password: string, city: string): Observable<boolean> {
    var user: IRegister;
    user = { email: email, password: password, name: name, city: city };
    return this.http.post<boolean>('https://localhost:44369/api/Account/Register',user
   ).pipe(catchError(this.errorHandler));
  }
  Login(email: string, password: string): Observable<boolean> {
    var user: ILogin;
    user = { email: email, password: password};
    return this.http.post<boolean>('https://localhost:44369/api/Account/Login', user
    ).pipe(catchError(this.errorHandler));
  }
  ApplyTution(email: string): Observable<boolean> {
    var tutionToUpdate = { AppliedBy: email};
    return this.http.post<boolean>('https://localhost:44369/api/Account/ApplyTution', tutionToUpdate
    ).pipe(catchError(this.errorHandler));
  }
  CheckEmail(email: string): Observable<boolean> {
    console.log(email)
    return this.http.post<boolean>('https://localhost:44369/api/Account/IsEmailRegistered',email
    ).pipe(catchError(this.errorHandler));
  }
  getallStudent(): Observable<ITestUser[]> {
    let tempVar = this.http.get<ITestUser[]>('https://localhost:44369/api/home/getallstudent'
    ).pipe(catchError(this.errorHandler));
    return tempVar;
  }
  getAllTeachers(): Observable<ITeacher[]> {
    let tempVar = this.http.get<ITeacher[]>('https://localhost:44369/api/home/getalltution'
    ).pipe(catchError(this.errorHandler));
    return tempVar;
  }
  getAllTutions(): Observable<ITution[]> {
    let tempVar = this.http.get<ITution[]>('https://localhost:44369/api/home/getalltution'
    ).pipe(catchError(this.errorHandler));
    return tempVar;
  }
  errorHandler(error: HttpErrorResponse) {
    console.error(error.url);
    return throwError(error);//(error.message || "Server Error");
  } 
}
