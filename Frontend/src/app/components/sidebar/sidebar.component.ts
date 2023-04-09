import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SignupComponent } from '../signup/signup.component';
import { LoginComponent } from '../login/login.component';
import { AuthService } from 'src/app/services/auth.service';

@Component({
selector: 'app-sidebar',
templateUrl: 'sidebar.component.html',
styleUrls: ['sidebar.component.css'],
})

export class SidebarComponent implements OnInit{
  showSideBar: boolean = false;
  isAuth: boolean = false;

  constructor(
    private dialog: MatDialog,
    private authService: AuthService
  ){}

  ngOnInit(): void {
    this.authService.isAuthenticated.subscribe(a => {
      this.isAuth = a;
    })
  }

  onToggle(){
    this.showSideBar = !this.showSideBar;
  }

  onSignup(){
    const dialogOptions = {
      bgcolor: 'white',
      autoFocus: false,
      maxHeight: '90vh',
    }

    this.dialog.open(SignupComponent, dialogOptions);
  }

  onLogin(){
    const dialogOptions = {
      bgcolor: 'white',
      autoFocus: false,
      maxHeight: '90vh',
    }

    this.dialog.open(LoginComponent, dialogOptions);
  }

  onLogout(){
    this.authService.logout();
  }
}
