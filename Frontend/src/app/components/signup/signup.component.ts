import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  signupForm!: FormGroup;
  submitted: boolean = false;
  passwordMismatch: boolean = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private dialogRef: MatDialogRef<SignupComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.signupForm = this.fb.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required]]
    })
  }

  get firstName(){
    return this.signupForm.get('firstName');
  }

  get lastName(){
    return this.signupForm.get('lastName');
  }

  get email(){
    return this.signupForm.get('email');
  }

  get password(){
    return this.signupForm.get('password');
  }

  get confirmPassword(){
    return this.signupForm.get('confirmPassword');
  }

  onSubmit(){
    this.submitted = true;

    if (this.confirmPassword?.value != this.password?.value){
      this.passwordMismatch = true;
      return;
    }

    if (!this.signupForm.valid){
      return;
    }

    this.authService.signup(this.signupForm.value).subscribe(u => {
      this.dialogRef.close();
    })
  }
}
