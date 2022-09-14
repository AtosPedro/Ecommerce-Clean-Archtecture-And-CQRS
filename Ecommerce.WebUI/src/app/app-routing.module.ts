import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './components/pages/login-page/login-page.component';
import { NotFoundPageComponent } from './components/pages/not-found-page/not-found-page.component';
import { SupplierIndexPageComponent } from './components/pages/supplier/supplier-index-page/supplier-index-page.component';
import { MaterialIndexPageComponent } from './components/pages/material/material-index-page/material-index-page.component';
import { OperationalUnitIndexPageComponent } from './components/pages/operationalUnit/operational-unit-index-page/operational-unit-index-page.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { ForgotPasswordComponent } from './components/pages/forgot-password/forgot-password.component';
import { OperationIndexPageComponent } from './components/pages/operation/operation-index-page/operation-index-page.component';
import { StoreIndexPageComponent } from './components/pages/store/store-index-page/store-index-page.component';
import { UserIndexPageComponent } from './components/pages/user/user-index-page/user-index-page.component';


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch:'full' },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'home', component: HomePageComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'produtos', component: MaterialIndexPageComponent },
  { path: 'fornecedores', component: SupplierIndexPageComponent },
  { path: 'operacoes', component: OperationIndexPageComponent },
  { path: 'unidades', component: OperationalUnitIndexPageComponent },
  { path: 'lojas', component: StoreIndexPageComponent },
  { path: 'usuarios', component: UserIndexPageComponent },
  { path: '**', component: NotFoundPageComponent },
];

@NgModule({

  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
