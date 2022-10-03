import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'forgot-password-form',
  templateUrl: './forgot-password-form.component.html',
  styleUrls: ['./forgot-password-form.component.css']
})
export class ForgotPasswordFormComponent implements OnInit {
  faEnvelope = faEnvelope;
  forgotPasswordForm = new FormGroup({
    email: new FormControl('')
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void{

  }

}
