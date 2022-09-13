import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './components/pages/login-page/login-page.component';
import { NotFoundPageComponent } from './components/pages/not-found-page/not-found-page.component';
import { ForgotPasswordComponent } from './components/pages/forgot-password/forgot-password.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { SupplierIndexPageComponent } from './components/pages/supplier/supplier-index-page/supplier-index-page.component';
import { SupplierFormPageComponent } from './components/pages/supplier/supplier-form-page/supplier-form-page.component';
import { MaterialIndexPageComponent } from './components/pages/material/material-index-page/material-index-page.component';
import { MaterialFormPageComponent } from './components/pages/material/material-form-page/material-form-page.component';
import { OperationFormPageComponent } from './components/pages/operation/operation-form-page/operation-form-page.component';
import { OperationIndexPageComponent } from './components/pages/operation/operation-index-page/operation-index-page.component';
import { OperationalUnitFormPageComponent } from './components/pages/operationalUnit/operational-unit-form-page/operational-unit-form-page.component';
import { OperationalUnitIndexPageComponent } from './components/pages/operationalUnit/operational-unit-index-page/operational-unit-index-page.component';
import { StoreFormPageComponent } from './components/pages/store/store-form-page/store-form-page.component';
import { StoreIndexPageComponent } from './components/pages/store/store-index-page/store-index-page.component';
import { UserFormPageComponent } from './components/pages/user/user-form-page/user-form-page.component';
import { UserIndexPageComponent } from './components/pages/user/user-index-page/user-index-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    NotFoundPageComponent,
    ForgotPasswordComponent,
    HomePageComponent,
    SupplierIndexPageComponent,
    SupplierFormPageComponent,
    MaterialIndexPageComponent,
    MaterialFormPageComponent,
    OperationFormPageComponent,
    OperationIndexPageComponent,
    OperationalUnitFormPageComponent,
    OperationalUnitIndexPageComponent,
    StoreFormPageComponent,
    StoreIndexPageComponent,
    UserFormPageComponent,
    UserIndexPageComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
