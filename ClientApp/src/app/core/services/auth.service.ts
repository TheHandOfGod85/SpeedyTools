import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginUrl = 'http://localhost:7197/user/login';
  private readonly TOKEN_NAME = 'token';
  get token() {
    return localStorage.getItem(this.TOKEN_NAME);
  }
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
            localStorage.setItem(this.TOKEN_NAME, result);
          }
        })
      );
  }

  logout() {
    localStorage.removeItem(this.TOKEN_NAME);
  }

  isLoggedIn() {
    let isTokenExpired = this.jwtHelper.isTokenExpired();
    return !isTokenExpired;
  }
  get currentUser() {
    if (!this.token) return null;
    let decodedToken = this.jwtHelper.decodeToken(this.token);
    return decodedToken;
  }
}
