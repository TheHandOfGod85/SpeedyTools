import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { AppError } from 'shared/errors/app-error';
import { BadInput } from 'shared/errors/bad-input-error';
import { NotFoundError } from 'shared/errors/not-found-error';
import { UnauthorizedError } from 'shared/errors/unauthorized-error';

@Injectable({
  providedIn: 'root',
})
export abstract class DataService {
  protected abstract url: string;

  constructor(private http: HttpClient) {}
  getAll(endPoint?: string): any {
    return this.http
      .get(this.url + endPoint)
      .pipe(catchError(this.handleError));
  }
  create(resource: any, endPoint?: string): any {
    return this.http
      .post(this.url + endPoint, resource)
      .pipe(catchError(this.handleError));
  }
  update(resource: any, id?: string): any {
    return this.http
      .put(this.url + id, resource)
      .pipe(catchError(this.handleError));
  }
  delete(id?: string): any {
    return this.http.delete(this.url + id).pipe(catchError(this.handleError));
  }
  get(id?: string): any {
    return this.http.delete(this.url + id).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 404) return throwError(() => new NotFoundError());
    if (error.status === 400) return throwError(() => new BadInput());
    if (error.status === 401) return throwError(() => new UnauthorizedError());
    return throwError(() => new AppError(error));
  }
}
