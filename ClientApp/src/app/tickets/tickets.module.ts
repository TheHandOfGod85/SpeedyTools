import { NgModule } from '@angular/core';
import { TicketsComponent } from './tickets.component';
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

@NgModule({
  declarations: [TicketsComponent, CreateTicketComponent],
  imports: [
    SharedModule,
    MatInputModule,
    MatFormFieldModule,
    MatTableModule,
    MatSortModule,
    RouterModule.forChild([]),
    ReactiveFormsModule,
    MatPaginatorModule,
  ],
  exports: [TicketsComponent, CreateTicketComponent],
  providers: [TicketsService],
})
export class TicketsModule {}
