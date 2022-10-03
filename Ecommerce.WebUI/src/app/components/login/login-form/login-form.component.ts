import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ErrorResponse } from 'src/app/comunication/ErrorResponse';
import { LogInAuthentication } from '../../../models/LogInAuthentication';
import { AuthService } from '../../../services/auth/auth.service';
import { faLock } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  faLock = faLock;
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
      let password =  this.loginForm.value.password;
      
      this.authService.logIn(username,password).subscribe(
        (auth: LogInAuthentication) => {
          this.authService.setToken(auth.data.token);
          if (this.authService.isLoggedIn())
            this.router.navigate(['admin']);
        }, (err: ErrorResponse) => {
          console.log(err);
        }
      );
    }
  }
}
