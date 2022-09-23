import { Injectable } from '@angular/core';
import { IStoreService } from '../../contracts/IStoreService';

@Injectable({
  providedIn: 'root'
})
export class StoreService implements IStoreService{

  constructor() { }
}
