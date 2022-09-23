import { Injectable } from '@angular/core';
import { IMaterialService } from '../../contracts/IMaterialService';

@Injectable({
  providedIn: 'root'
})

export class MaterialService implements IMaterialService {

  constructor() { }

  LogIn(userName: string, password:string) {

  }
}
