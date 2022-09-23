import { Injectable } from '@angular/core';
import { IUserService } from '../../contracts/IUserService';
import { User } from '../../models/User';

@Injectable({
  providedIn: 'root'
})

export class UserService implements IUserService{

  constructor() { }

  logIn(userName: string, password: string) {

  }

  create(user: User) {

  }

  update(user: User) {

  }

  get(): User[]{
    return[]
  }

  //getByGuid(guid: string): User {

  //}
}
