import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ConfirmEmailModel, JwtTokenModel, LoginModel, ResetPasswordModel, SignupModel } from '../models/auth';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticated: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(localStorage['token']);

  constructor(private http: HttpClient) { }

  getCurrentUserId(){
    var token = localStorage.getItem('token');

    if (token == null){
      return null;
    }

    const tokenInfo = this.getDecodedAccessToken(token);
    console.log(tokenInfo);
    var id = tokenInfo.sub;
    return id;
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }

  login(loginModel: LoginModel): Observable<JwtTokenModel>{
    return this.http.post<JwtTokenModel>(environment.apiUrl + 'auth/login', loginModel)
      .pipe(tap(r => {
        localStorage.setItem('token', r.token);
        this.isAuthenticated.next(true);
      }))
  }

  signup(signupModel: SignupModel): Observable<any>{
    return this.http.post<any>(environment.apiUrl + 'auth/signup', signupModel);
  }

  logout(){
    localStorage.removeItem('token');
    this.isAuthenticated.next(false);
  }

  confirmEmail(confirmEmailModel: ConfirmEmailModel){
    return this.http.get(environment.apiUrl + 'auth/confirmEmail', {
      params: {
        email: confirmEmailModel.email,
        token: confirmEmailModel.token
      }
    })
  }

  forgotPassword(email: string){
    return this.http.put(environment.apiUrl + 'auth/forgotPassword', {email: email});
  }

  resetPassword(model: ResetPasswordModel){
    return this.http.put(environment.apiUrl + 'auth/resetPassword', model);
  }
}
