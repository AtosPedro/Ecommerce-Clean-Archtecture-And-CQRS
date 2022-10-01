import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './components/login/login-page/login-page.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  //{
  //  path: 'admin',
  //  canActivate:[AuthGuard],
  //  loadChildren: () => import('./modules/admin/admin.module').then((m) => m.AdminModule)
  //}
  {
    path: '',
    component: LoginPageComponent
  }
];

@NgModule({

  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
