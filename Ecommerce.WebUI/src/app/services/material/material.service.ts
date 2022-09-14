import { Injectable } from '@angular/core';
import { IMaterialService } from '../../interfaces/IMaterialService';

@Injectable({
  providedIn: 'root'
})

export class MaterialService implements IMaterialService {

  constructor() { }
}
