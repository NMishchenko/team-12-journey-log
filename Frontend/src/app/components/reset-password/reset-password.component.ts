import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPasswordModel } from 'src/app/models/auth';
import { AuthService } from 'src/app/services/auth.service';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent {
  resetPasswordForm!: FormGroup;
  submitted: boolean = false;
  email: string;
  token: string;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute)
  {
    this.route.queryParams.subscribe(p => {
      this.email = p['email'];
      this.token = p['token'];
    })
  }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void{
    this.resetPasswordForm = this.fb.group({
      confirmPassword: [null, [Validators.required]],
      password: [null, [Validators.required]]
    })
  }

  get password(){
    return this.resetPasswordForm.get('password');
  }

  get confirmPassword(){
    return this.resetPasswordForm.get('confirmPassword');
  }

  onSubmit(){
    this.submitted = true;

    if (this.resetPasswordForm.invalid || this.password?.value != this.confirmPassword?.value){
      return;
    }

    const resetPasswordModel = new ResetPasswordModel();

    resetPasswordModel.email = this.email;
    resetPasswordModel.password = this.password?.value;
    resetPasswordModel.token = this.token;

    this.authService.resetPassword(resetPasswordModel).subscribe(_ => {
      this.router.navigateByUrl('/');
    })
  }
}
