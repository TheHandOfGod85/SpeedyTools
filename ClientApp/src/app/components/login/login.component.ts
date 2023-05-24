import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  invalidLogin: boolean = false;

  constructor(private router: Router, private authService: AuthService) {}

  signIn(credentials: any) {
    this.authService.login(credentials).subscribe((result: any) => {
      if (result) this.router.navigate(['/']);
      else this.invalidLogin = true;
    });
  }
}
