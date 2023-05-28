import { ErrorHandler, Injectable } from '@angular/core';
import { UnauthorizedError } from './unauthorized-error';
import { NotFoundError } from './not-found-error';
import { Router } from '@angular/router';
@Injectable()
export class AppErrorHandler implements ErrorHandler {
  constructor(private router: Router) {}
  handleError(error: any): void {
    if (error instanceof UnauthorizedError) {
      // Handle unauthorized error specifically
      this.router.navigate(['/login']);
      alert('Unauthorized Error: Please login or authenticate.');
      console.log('Unauthorized Error:', error);
    } else if (error instanceof NotFoundError) {
      // Handle not found error specifically
      alert('Not Found Error: The requested resource was not found.');
      console.log('Not Found Error:', error);
    } else {
      // Handle other errors
      alert('An unexpected error occurred');
      console.log(error);
    }
  }
}
export const AppErrorProvider = {
  provide: ErrorHandler,
  useClass: AppErrorHandler,
};
