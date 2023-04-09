import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {
  forgotPasswordForm!: FormGroup;
  submitted: boolean = false;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<ForgotPasswordComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void{
    this.forgotPasswordForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
    })
  }

  get email(){
    return this.forgotPasswordForm.get('email');
  }

  onSubmit(){
    this.submitted = true;

    if (this.forgotPasswordForm.invalid){
      return;
    }

    this.authService.forgotPassword(this.email?.value).subscribe(r => {
      this.dialogRef.close();
    })
  }
}
