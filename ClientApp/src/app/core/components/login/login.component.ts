import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  isLoading = false;
  errors = '';

  constructor(private router: Router, private authService: AuthService) {}

  signIn(form: NgForm) {
    if (!form.valid) {
      return;
    }
    const email = form.value.email;
    const password = form.value.password;
    this.isLoading = true;
    this.authService.login(email, password).subscribe({
      next: (token) => {
        console.log(token);
        this.isLoading = false;
        this.errors = '';
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.log(error.error);
        this.isLoading = false;
        this.errors = error.error;
      },
    });
    form.reset();
  }
}
