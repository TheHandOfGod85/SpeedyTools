import { NgModule } from '@angular/core';
import { TicketsComponent } from './tickets.component';
import { SharedModule } from 'shared/shared.module';
import { TicketsService } from './tickets.service';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [TicketsComponent],
  imports: [SharedModule, MatTableModule, MatSortModule],
  exports: [TicketsComponent],
  providers: [TicketsService],
})
export class TicketsModule {}
