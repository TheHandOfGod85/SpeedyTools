import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable, NgZone } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';

@Injectable()
export class AppErrorHandler implements ErrorHandler {
  constructor(
    private router: Router,
    private zone: NgZone,
    private snackbar: MatSnackBar
  ) {}
  handleError(err: unknown): void {
    // Handle globally errors
    this.zone.run(() => {
      if (err instanceof HttpErrorResponse) {
        if (err instanceof ErrorEvent) {
          console.warn('Error Event', err);
        } else {
          console.warn(`error status : ${err.status} ${err.statusText}`);
          switch (err.status) {
            case 401: //login
              this.router.navigateByUrl('/');
              this.snackbar.open('You`re not logged in!', 'Close', {
                duration: 2000,
              });
              break;
            case 403: //forbidden
              this.snackbar.open(
                'You`ve not got the right permission!',
                'Close',
                {
                  duration: 2000,
                }
              );
              break;
          }
        }
      } else {
        console.warn(err);
        this.snackbar.open(
          'Error was detected! We are already working on it!',
          'Close',
          {
            duration: 2000,
          }
        );
      }
      // rethrow the error
      return throwError(() => {
        console.log('Error rethrown by HTTP interceptor');
        return err;
      });
    });
    console.warn(`Caught by Custom Global Error Handler: `, err);
  }
}
export const AppErrorProvider = {
  provide: ErrorHandler,
  useClass: AppErrorHandler,
};
