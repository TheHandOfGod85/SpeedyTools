import { Injectable } from '@angular/core';
import { HttpRequestsService } from 'shared/http-requests.service';
import { Ticket } from 'shared/models/Ticket';

@Injectable({
  providedIn: 'root',
})
export class TicketsService {
  url = 'http://localhost:7197/ticket/';
  private readonly httpRequests;
  constructor(private requests: HttpRequestsService) {
    this.httpRequests = this.requests.requests;
  }
  getAll() {
    return this.httpRequests.get<Ticket[]>(this.url + 'userTickets');
  }
}
