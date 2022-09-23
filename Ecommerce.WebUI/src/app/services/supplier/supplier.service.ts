import { Injectable } from '@angular/core';
import { ISupplierService } from '../../contracts/ISupplierService';

@Injectable({
  providedIn: 'root'
})
export class SupplierService implements ISupplierService{

  constructor() { }
}
