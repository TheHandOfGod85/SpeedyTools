import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { HttpRequestsService } from './http-requests.service';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptorProvider } from './auth.interceptor';

@NgModule({
  declarations: [],
  imports: [
    HttpClientModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token');
        },
        allowedDomains: ['http://localhost:7197'],
      },
    }),
  ],
  providers: [HttpRequestsService, AuthInterceptorProvider],
  exports: [FormsModule, MatButtonModule, CommonModule],
})
export class SharedModule {}
