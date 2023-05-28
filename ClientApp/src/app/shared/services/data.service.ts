import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { AppError } from 'shared/errors/app-error';
import { BadInput } from 'shared/errors/bad-input-error';
import { NotFoundError } from 'shared/errors/not-found-error';
import { UnauthorizedError } from 'shared/errors/unauthorized-error';

@Injectable({
  providedIn: 'root',
})
export abstract class DataService<T> {
  protected abstract url: string;

  constructor(private http: HttpClient) {}
  getAll(endPoint?: string): Observable<T[]> {
    return this.http
      .get<T[]>(this.url + endPoint)
      .pipe(catchError(this.handleError));
  }
  create(resource: T, endPoint?: string): Observable<T> {
    return this.http
      .post<T>(this.url + endPoint, resource)
      .pipe(catchError(this.handleError));
  }
  update(resource: T, id?: string): Observable<T> {
    return this.http
      .put<T>(this.url + id, resource)
      .pipe(catchError(this.handleError));
  }
  delete(id?: string): Observable<T> {
    return this.http
      .delete<T>(this.url + id)
      .pipe(catchError(this.handleError));
  }
  get(id?: string): Observable<T> {
    return this.http
      .delete<T>(this.url + id)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 404) return throwError(() => new NotFoundError());
    if (error.status === 400) return throwError(() => new BadInput());
    if (error.status === 401) return throwError(() => new UnauthorizedError());
    return throwError(() => new AppError(error));
  }
}
