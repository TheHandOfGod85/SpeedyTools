import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  isLoading = false;
  errors? = '';
  constructor(private authService: AuthService, private router: Router) {}

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
        this.router.navigateByUrl('/tickets');
      },
      error: (error: HttpErrorResponse) => {
        if (error.status === 400) {
          this.errors = error.error;
          this.isLoading = false;
        } else {
          this.isLoading = false;
          throw error;
        }
      },
    });
    form.reset();
  }
}
