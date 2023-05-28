import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DataService } from 'shared/services/data.service';

@Injectable({
  providedIn: 'root',
})
export class TicketsService extends DataService {
  protected override url: string = 'http://localhost:7197/ticket/';
  constructor(http: HttpClient) {
    super(http);
  }
}
