import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}
  login(email: string, password: string) {
    return this.http.post('http://localhost:7197/user/login', {
      email: email,
      password: password,
    });
  }

  logout() {}

  isLoggedIn() {
    return false;
  }
}
