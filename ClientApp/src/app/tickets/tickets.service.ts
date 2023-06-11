import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from 'shared/models/Ticket';
import { DataService } from 'shared/services/data.service';

@Injectable({
  providedIn: 'root',
})
export class TicketsService extends DataService<Ticket> {
  protected override url: string = 'http://localhost:7197/admin/';
  constructor(http: HttpClient) {
    super(http);
  }
}
