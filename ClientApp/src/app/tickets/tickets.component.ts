import { Component, OnInit, ViewChild } from '@angular/core';
import { TicketsService } from './tickets.service';
import { Ticket } from 'shared/models/Ticket';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ResponsiveService } from 'shared/services/responsive.service';
import { DialogService } from 'shared/services/dialog.service';
import { CreateTicketComponent } from './components/create-ticket/create-ticket.component';
import { MatDialogConfig } from '@angular/material/dialog';

@Component({
  selector: 'app-tickets',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TicketsComponent implements OnInit {
  displayedColumns: string[] = ['created', 'title', 'description'];
  dataSource!: MatTableDataSource<Ticket>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(
    private ticketService: TicketsService,
    public responsiveService: ResponsiveService,
    private dialog: DialogService
  ) {}

  ngOnInit() {
    this.getAllTickets();
  }

  getAllTickets() {
    this.ticketService.getAll('userTickets').subscribe({
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openDialog() {
    const dialogConfig: MatDialogConfig = {
      width: '500px',
      height: '450px',
    };
    this.dialog.openDialog(CreateTicketComponent, dialogConfig).subscribe({
      next: (result: any) => {
        this.getAllTickets();
      },
    });
  }
}
