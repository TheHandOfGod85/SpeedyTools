import { Component, ViewChild } from '@angular/core';
import { Ticket } from 'shared/models/Ticket';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { TicketsService } from 'app/tickets/tickets.service';
import { CreateTicketComponent } from '../create-ticket/create-ticket.component';
import { AuthService } from 'app/core/services/auth.service';
import { PopUpComponent } from 'app/core/components/pop-up/pop-up.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-table-ticket',
  templateUrl: './table-ticket.component.html',
  styleUrls: ['./table-ticket.component.css'],
})
export class TableTicketComponent {
  displayedColumns: string[] = [
    'created',
    'appUserName',
    'title',
    'description',
    'action',
  ];
  dataSource!: MatTableDataSource<Ticket>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(
    private ticketService: TicketsService,
    private popUp: MatDialog,
    public authService: AuthService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.getAllTickets();
  }

  getAllTickets() {
    this.ticketService.getAll('getAllTickets').subscribe({
      next: (tickets: Ticket[]) => {
        this.dataSource = new MatTableDataSource(tickets);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err: any) => {
        console.log(err);
      },
    });
  }
  deleteTicket(id: string) {
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
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
