import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewProductsComponent } from './view-products/view-products.component';
import { TwoWayBindingComponent } from './two-way-binding/two-way-binding.component';
import { LoginComponent } from './login/login.component';
import { ServiceTestingComponent } from './service-testing/service-testing.component';
import { ProductService } from './quickKart-services/product-service/product.service';
import { CommonLayoutComponent } from './common-layout/common-layout.component';
import { HomeComponent } from './home/home.component';
import { HtmlLearningComponent } from './html-learning/html-learning.component';
import { UpdateComponent } from './update/update.component';
import { NestedCheckComponent } from './nested-check/nested-check.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { ViewTutionComponent } from './view-tution/view-tution.component';
@NgModule({
  declarations: [
    AppComponent,
    ViewProductsComponent,
    TwoWayBindingComponent,
    LoginComponent,
    ServiceTestingComponent,
    CommonLayoutComponent,
    HomeComponent,
    HtmlLearningComponent,
    UpdateComponent,
    NestedCheckComponent,
    RegisterComponent,
    AdminPageComponent,
    ViewTutionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
