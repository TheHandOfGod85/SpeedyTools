import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}
  login(credentials: any) {
    return this.http
      .post('http://localhost:7197/user/login', JSON.stringify(credentials))
      .pipe(
        map((response) => {
          console.log(response);
        })
      );
  }

  logout() {}

  isLoggedIn() {
    return false;
  }
}
