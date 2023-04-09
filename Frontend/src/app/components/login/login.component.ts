import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/auth';
import { AuthService } from 'src/app/services/auth.service';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm!: FormGroup;
  submitted: boolean = false;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<LoginComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void{
    this.loginForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    })
  }

  get email(){
    return this.loginForm.get('email');
  }

  get password(){
    return this.loginForm.get('password');
  }

  onSubmit(){
    this.submitted = true;

    if (this.loginForm.invalid){
      return;
    }

    const loginModel: LoginModel = this.loginForm.value;
    this.authService.login(loginModel).subscribe(l => {
      this.dialogRef.close();
    });
  }

  onForgotPassword(){
    this.dialog.open(ForgotPasswordComponent,{
      autoFocus: false,
      maxHeight: '90vh'
    });
  }
}
