import { Component, OnInit } from '@angular/core';
import { TicketsService } from './tickets.service';
import { Ticket } from 'shared/models/Ticket';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-tickets',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TicketsComponent implements OnInit {
  tickets: Ticket[] = [];
  ticketId = '';
  displayedColumns: string[] = ['created', 'title', 'description'];
  constructor(private ticketService: TicketsService) {}

  ngOnInit() {
    this.getAllTickets();
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
      next: (ticket: Ticket) => {
        this.ticketId = ticket.id;
      },
    });
    form.reset();
  }
}
