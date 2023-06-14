import { NgModule } from '@angular/core';
import { SharedModule } from 'shared/shared.module';
import { TicketsService } from './tickets.service';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { RouterModule } from '@angular/router';
import { CreateTicketComponent } from './components/create-ticket/create-ticket.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { TicketsComponent } from './tickets.component';
import { TableTicketComponent } from './components/table-ticket/table-ticket.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TicketListComponent } from './components/ticket-list/ticket-list.component';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    TicketsComponent,
    CreateTicketComponent,
    TableTicketComponent,
    TicketListComponent,
  ],
  imports: [
    SharedModule,
    MatInputModule,
    MatFormFieldModule,
    MatTableModule,
    MatSortModule,
    RouterModule.forChild([]),
    ReactiveFormsModule,
    MatPaginatorModule,
    MatDialogModule,
    MatListModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule
  ],
  exports: [
    TicketsComponent,
    CreateTicketComponent,
    TableTicketComponent,
    TicketListComponent,
  ],
  providers: [TicketsService],
})
export class TicketsModule {}
