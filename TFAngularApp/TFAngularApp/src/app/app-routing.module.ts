  import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ViewProductsComponent } from './view-products/view-products.component';
import { TwoWayBindingComponent } from './two-way-binding/two-way-binding.component';
import { ServiceTestingComponent } from './service-testing/service-testing.component';
import { HomeComponent } from './home/home.component';
import { UpdateComponent } from './update/update.component';
import { RegisterComponent } from './register/register.component';
import { HtmlLearningComponent } from './html-learning/html-learning.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'view', component: ViewProductsComponent },
  { path: 'update/:name/:age', component: UpdateComponent },
  { path: 'twoWay/:emailId', component: TwoWayBindingComponent },
  { path: 'serviceTesting', component: ServiceTestingComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'html', component: HtmlLearningComponent },
  { path: '**', component: HomeComponent }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
