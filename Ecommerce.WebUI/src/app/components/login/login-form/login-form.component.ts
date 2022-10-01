import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LogInAuthentication } from '../../../models/LogInAuthentication';
import { AuthService } from '../../../services/auth/auth.service';

@Component({
  selector: 'login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.loginForm.valid) {
      let username = this.loginForm.value.username;
      this.authService.logIn(username, this.loginForm.value.password).subscribe(
        (auth: LogInAuthentication) => {
          let data = auth.data;
          this.authService.setToken(data.token);
          if (this.authService.isLoggedIn()) {
            this.router.navigate(['']);
          }
        }, (err: HttpErrorResponse) => {
          console.log(err.error);
        }
      );
    }
  }
}
