import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TicketsService } from './tickets.service';
import { Ticket } from 'shared/models/Ticket';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { CreateTicketComponent } from './components/create-ticket/create-ticket.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PopUpComponent } from 'app/core/components/pop-up/pop-up.component';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: [],
})
export class TicketsComponent implements OnInit {
  tickets: Ticket[] = [];
  @Output() deleteTicket: EventEmitter<string> = new EventEmitter<string>();
  constructor(
    private ticketService: TicketsService,
    private popUp: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.getAllTickets();
  }

  getAllTickets() {
    this.ticketService.getAll('getAllTickets').subscribe({
      next: (tickets: Ticket[]) => {
        this.tickets = tickets;
      },
      error: (err: any) => {
        console.log(err);
      },
    });
  }

  emitDeleteTicket(id: string) {
    const dialogConfig: MatDialogConfig = {
      width: '350px',
      height: '290px',
      data: {
        title: 'Delete Ticket',
        content: 'Are you sure you want to delete this ticket?',
        submit: () =>
          this.ticketService.delete(id, `delete/`).subscribe({
            next: () => {
              this.snackBar.open('Ticket deleted successfully!', 'Done', {
                verticalPosition: 'top',
              });
            },
          }),
      },
    };
    var afteClosed = this.popUp.open(PopUpComponent, dialogConfig);
    afteClosed.afterClosed().subscribe({
      next: () => {
        this.getAllTickets();
      },
    });
  }

  openDialog() {
    const dialogConfig: MatDialogConfig = {
      width: '350px',
      height: '390px',
    };
    var afteClosed = this.popUp.open(CreateTicketComponent, dialogConfig);
    afteClosed.afterClosed().subscribe({
      next: () => {
        this.getAllTickets();
      },
    });
  }
}
