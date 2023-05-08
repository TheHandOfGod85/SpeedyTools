import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { UsersFormComponent } from './components/users-form/users-form.component';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [AppComponent, UsersFormComponent, NavbarComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'users/new', component: UsersFormComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
