import { Component, OnInit } from '@angular/core';
import { faBomb } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {
  faBomb = faBomb;
  constructor() { }

  ngOnInit(): void {
  }

}
