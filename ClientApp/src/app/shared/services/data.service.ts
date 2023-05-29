import {
  HttpClient,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Sort } from '@angular/material/sort';

@Injectable({
  providedIn: 'root',
})
export abstract class DataService<T> {
  protected abstract url: string;

  constructor(private http: HttpClient) {}
  getAll(endPoint?: string): Observable<T[]> {
    return this.http.get<T[]>(this.url + endPoint);
  }
  create(resource: T, endPoint?: string): Observable<T> {
    return this.http.post<T>(this.url + endPoint, resource);
  }
  update(resource: T, id?: string): Observable<T> {
    return this.http.put<T>(this.url + id, resource);
  }
  delete(id?: string): Observable<T> {
    return this.http.delete<T>(this.url + id);
  }
  get(id?: string): Observable<T> {
    return this.http.delete<T>(this.url + id);
  }
}
