import { Component, OnInit } from '@angular/core';
import { TicketsService } from './tickets.service';
import { Ticket } from 'shared/models/Ticket';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css'],
})
export class TicketsComponent implements OnInit {
  tickets: Ticket[] = [];
  ticketId = '';
  constructor(private ticketService: TicketsService) {}

  ngOnInit() {
    // this.getAllTickets();
  }

  getAllTickets() {
    this.ticketService.getAll('userTickets').subscribe({
      next: (tickets: Ticket[]) => {
        this.tickets = tickets;
      },
    });
  }
  createTicket(form: NgForm) {
    this.ticketService.create(form.value, 'create').subscribe({
      next: (ticketId: string) => {
        this.ticketId = ticketId;
      },
    });
    form.reset();
  }
}
