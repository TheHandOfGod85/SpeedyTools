import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';
import { Ticket } from 'shared/models/Ticket';
import { AuthService } from 'app/core/services/auth.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-table-ticket',
  templateUrl: './table-ticket.component.html',
  styleUrls: ['./table-ticket.component.css'],
})
export class TableTicketComponent {
  @Output() openDialog = new EventEmitter<void>();
  @Output() deleteTicket = new EventEmitter<string>();
  @Input() tickets = new MatTableDataSource<Ticket>();
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  displayedColumns: string[] = [
    'created',
    'appUserName',
    'title',
    'description',
    'action',
  ];

  constructor(public authService: AuthService) {}
  ngAfterViewInit() {
    this.tickets.paginator = this.paginator;
    this.tickets.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    if (this.tickets) {
      this.tickets.filter = filterValue.trim().toLowerCase();

      if (this.tickets.paginator) {
        this.tickets.paginator.firstPage();
      }
    }
  }
}
