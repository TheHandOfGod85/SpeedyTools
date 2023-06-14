import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Ticket } from 'shared/models/Ticket';

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.css'],
})
export class TicketListComponent {
  @Input('ticket') ticket!: Ticket;
  @Output() deleteTicket: EventEmitter<string> = new EventEmitter<string>();

  onDeleteTicket() {
    this.deleteTicket.emit(this.ticket.id);
  }
}
