import { NgModule } from '@angular/core';
import { TicketsComponent } from './tickets.component';
import { SharedModule } from 'shared/shared.module';

@NgModule({
  declarations: [TicketsComponent],
  imports: [SharedModule],
  exports: [TicketsComponent],
})
export class TicketsModule {}
