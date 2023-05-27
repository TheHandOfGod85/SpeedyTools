import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginUrl = 'http://localhost:7197/user/login';
  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {}
  login(email: string, password: string) {
    return this.http
      .post<string>(this.loginUrl, {
        email: email,
        password: password,
      })
      .pipe(
        map((response) => {
          let result = response;
          if (result) {
            localStorage.setItem('token', result);
          }
        })
      );
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn() {
    let isTokenExpired = this.jwtHelper.isTokenExpired();
    return !isTokenExpired;
  }
  get currentUser() {
    let token = localStorage.getItem('token');
    if (!token) return null;
    let decodedToken = this.jwtHelper.decodeToken(token);
    return decodedToken;
  }
}
