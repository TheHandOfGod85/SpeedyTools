import { CreateTicketComponent } from './tickets/components/create-ticket/create-ticket.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { Routes } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { TicketsComponent } from './tickets/tickets.component';
import { AuthGuard } from 'shared/guards/auth-guard.service';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'tickets', component: TicketsComponent, canActivate: [AuthGuard] },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404' },
];
