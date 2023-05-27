import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class HttpRequestsService {
  // token = localStorage.getItem('token');
  // headers = new HttpHeaders().set('Authorization', `Bearer ${this.token}`);
  constructor(private http: HttpClient) {}
  public requests = {
    get: <T>(url: string) => this.http.get<T>(url),
    post: <T>(url: string, body?: {}) => this.http.post<T>(url, body),
    put: <T>(url: string, body?: {}) => this.http.put<T>(url, body),
    del: <T>(url: string) => this.http.delete<T>(url),
  };
}
