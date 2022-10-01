import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';
import { LogInAuthentication } from '../../models/LogInAuthentication';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  serviceUrl = environment.apiUrl + '/v1/login'
  constructor(
    private httpClient: HttpClient,
    private router: Router,
  ) { }

  setToken(token: string){
    localStorage.setItem('authToken', token);
  }
  
  getToken(): string | null{
    return localStorage.getItem('authToken');
  }

  isLoggedIn(): boolean{
    return this.getToken() !== null;
  }

  logOut(){
    localStorage.removeItem('authToken');
    this.router.navigate(['login']);
  }

  logIn(username: string | null | undefined, password: string | null | undefined): Observable<LogInAuthentication> {
    return this.httpClient.post<LogInAuthentication>(this.serviceUrl, { username, password });
  }
}
