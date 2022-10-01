import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) { }

  setToken(token: string){
    localStorage.setItem('authToken', token);
  }
  
  getToken(): string | null{
    return localStorage.getItem('authToken');
  }

  isLoggedIn(){
    return this.getToken() !== null;
  }

  logOut(){
    localStorage.removeItem('authToken');
    this.router.navigate(['login']);
  }

  logIn(username:string, password:string) : Observable<any>{
    return of();
  }

}
