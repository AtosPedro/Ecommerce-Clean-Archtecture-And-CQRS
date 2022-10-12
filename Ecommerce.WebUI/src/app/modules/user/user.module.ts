import { NgModule } from '@angular/core';

import { UserRegistrationFormComponent } from '../../components/user/user-registration-form/user-registration-form.component';
import { UserRegistrationPageComponent } from '../../components/user/user-registration-page/user-registration-page.component';
import { UserProfilePageComponent } from '../../components/user/user-profile-page/user-profile-page.component';
import { UserProfileFormComponent } from '../../components/user/user-profile-form/user-profile-form.component';

const UserComponents = [
  UserRegistrationFormComponent,
  UserRegistrationPageComponent,
  UserProfilePageComponent,
  UserProfileFormComponent,
]


@NgModule({
  declarations: [UserComponents],
  exports: [UserComponents]
})
export class UserModule { }
