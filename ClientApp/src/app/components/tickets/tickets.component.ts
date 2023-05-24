import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css'],
})
export class TicketsComponent {
  tickets?: any[];
  private url: string = 'http://localhost:7197/';
  constructor(private http: HttpClient) {
    http.get<any>(this.url + 'api/getAllTickets').subscribe((response) => {
      this.tickets = response;
    });
  }
  createTicket(input: HTMLInputElement) {
    let ticket = { title: input.title };
    this.http.post(this.url + 'ticket/create', ticket).subscribe((response) => {
      console.log(response);
    });
  }
}
