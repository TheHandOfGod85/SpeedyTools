import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptorProvider } from 'shared/interceptors/auth.interceptor';
import { AppErrorProvider } from './errors/app-error-handler';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [NotFoundComponent],
  imports: [
    HttpClientModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    RouterModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token');
        },
        allowedDomains: ['http://localhost:7197'],
      },
    }),
  ],
  providers: [AuthInterceptorProvider, AppErrorProvider],
  exports: [FormsModule, MatButtonModule, CommonModule],
})
export class SharedModule {}
