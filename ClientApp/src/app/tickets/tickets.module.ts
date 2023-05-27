import { NgModule } from '@angular/core';
import { TicketsComponent } from './tickets.component';
import { SharedModule } from 'shared/shared.module';
import { TicketsService } from './tickets.service';

@NgModule({
  declarations: [TicketsComponent],
  imports: [SharedModule],
  exports: [TicketsComponent],
  providers: [TicketsService],
})
export class TicketsModule {}
