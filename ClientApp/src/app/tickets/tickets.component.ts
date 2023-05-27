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
  tickets?: Ticket[];
  ticketId = '';
  constructor(private ticketService: TicketsService) {}

  ngOnInit() {
    // this.getAllTickets();
  }

  getAllTickets() {
    this.ticketService.getAll().subscribe((data) => {
      this.tickets = [...data];
    });
  }
  createTicket(form: NgForm) {
    this.ticketService.create(form.value).subscribe((data) => {
      this.ticketId = data;
      console.log(this.ticketId);
    });
    form.reset();
  }
}
