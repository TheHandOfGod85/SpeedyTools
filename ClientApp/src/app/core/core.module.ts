import { NgModule } from '@angular/core';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'shared/shared.module';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [LoginComponent, HomeComponent],
  imports: [RouterModule, SharedModule],
  providers: [AuthService],
  exports: [LoginComponent, HomeComponent],
})
export class CoreModule {}
