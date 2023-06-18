import { inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import {
  CanActivateFn,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { AuthService } from 'app/core/services/auth.service';
import { Observable } from 'rxjs';

export const AuthGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
):
  | Observable<boolean | UrlTree>
  | Promise<boolean | UrlTree>
  | boolean
  | UrlTree => {
  const router: Router = inject(Router);
  const authService: AuthService = inject(AuthService);
  const snackbar: MatSnackBar = inject(MatSnackBar);
  if (!authService.isLoggedIn()) {
    router.navigateByUrl('/');
    snackbar.open('You are not logged in', 'Done', {
      verticalPosition: 'top',
    });
    return false;
  } else return true;
};
