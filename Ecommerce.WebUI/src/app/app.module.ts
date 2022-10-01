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
import { LoginComponentComponent } from './components/login/login-component/login-component.component';
import { LoginPageComponent } from './components/login/login-page/login-page.component';

@NgModule({
 declarations: [
   AppComponent,
   AdminDashboardComponent,
   LoginComponentComponent,
   LoginPageComponent,   
 ],
 imports: [
   BrowserModule,
   AppRoutingModule,
   NgbModule,
   FontAwesomeModule,
   BrowserAnimationsModule,
   MaterialModule,
   ReactiveFormsModule
 ],
 providers: [],
 bootstrap: [AppComponent]
})
export class AppModule { }
