import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule} from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapComponent } from './components/map/map.component';
import { MarkerDialogComponent } from './components/marker-dialog/marker-dialog.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { MatNativeDateModule } from '@angular/material/core';
import {MatSidenavModule} from '@angular/material/sidenav';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component'
import { JWT_OPTIONS, JwtHelperService, JwtInterceptor } from '@auth0/angular-jwt';
import { AuthService } from './services/auth.service';
import { EmailConfirmationComponent } from './components/email-confirmation/email-confirmation.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    MarkerDialogComponent,
    SidebarComponent,
    MarkerDialogComponent,
    LoginComponent,
    SignupComponent,
    EmailConfirmationComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatNativeDateModule,
    MatSidenavModule,
    HttpClientModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy},
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }, AuthService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },JwtHelperService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
