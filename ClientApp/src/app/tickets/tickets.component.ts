import { Component, OnInit } from '@angular/core';
import { TicketsService } from './tickets.service';
import { Ticket } from 'shared/models/Ticket';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css'],
})
export class TicketsComponent implements OnInit {
  tickets?: Ticket[];
  constructor(private ticketService: TicketsService) {}

  ngOnInit() {
    this.getAllTickets();
  }

  getAllTickets() {
    this.ticketService.getAll().subscribe((data) => {
      this.tickets = [...data];
      console.log(this.tickets);
    });
  }
}
