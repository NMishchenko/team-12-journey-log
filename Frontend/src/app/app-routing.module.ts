import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailConfirmationComponent } from './components/email-confirmation/email-confirmation.component';
import { MapComponent } from './components/map/map.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';

const routes: Routes = [
  {path: '', component: MapComponent},
  {path: 'auth/confirm-email', component: EmailConfirmationComponent},
  {path: 'auth/forgot-password', component: ForgotPasswordComponent},
  {path: 'auth/password-recovery', component: ResetPasswordComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
