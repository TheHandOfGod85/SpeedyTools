import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  isLoading = false;
  errors: string[] = [];
  loginForm: FormGroup;
  constructor(
    public authService: AuthService,
    private router: Router,
    private _fb: FormBuilder
  ) {
    this.loginForm = _fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  signIn() {
    if (this.loginForm.valid) {
      this.isLoading = true;
      const email = this.loginForm.get('email')?.value;
      const password = this.loginForm.get('password')?.value;
      this.authService.login(email, password).subscribe({
        next: (token) => {
          console.log(token);
          this.isLoading = false;
          this.errors?.splice(0);
          this.router.navigateByUrl('/tickets');
        },
        error: (error: HttpErrorResponse) => {
          if (error.status === 400) {
            console.log(error);
            if (error.error.errors) {
              this.errors = Object.values<string[]>(error.error.errors).flat();
            } else {
              this.errors = error.error;
            }
            this.isLoading = false;
          } else {
            this.isLoading = false;
            throw error;
          }
        },
      });
    }
  }
}
