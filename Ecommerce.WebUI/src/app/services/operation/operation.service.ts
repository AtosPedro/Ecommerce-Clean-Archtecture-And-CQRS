import { Injectable } from '@angular/core';
import { IOperationsService } from '../../contracts/IOperationService';

@Injectable({
  providedIn: 'root'
})
export class OperationService implements IOperationsService{

  constructor() { }
}
