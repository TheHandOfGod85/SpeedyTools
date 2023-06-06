import { Component, OnInit } from '@angular/core';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'ClientApp';

  constructor(public authService: AuthService) {}

  // isHomePage(): boolean {
  //   return this.router.url === '/';
  // }
}
