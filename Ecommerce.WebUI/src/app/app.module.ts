import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './modules/material/material.module';
import { AdminDashboardComponent } from './components/admin/admin-dashboard/admin-dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginPageComponent } from './components/login/login-page/login-page.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginFormComponent } from './components/login/login-form/login-form.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { ProductPageComponent } from './components/pages/product-page/product-page.component';
import { SupplierPageComponent } from './components/pages/supplier-page/supplier-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminDashboardComponent,
    LoginPageComponent,
    LoginFormComponent,
    HomePageComponent,
    ProductPageComponent,
    SupplierPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
