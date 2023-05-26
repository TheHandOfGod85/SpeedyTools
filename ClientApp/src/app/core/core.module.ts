import { NgModule } from '@angular/core';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'shared/shared.module';

@NgModule({
  declarations: [LoginComponent, HomeComponent],
  imports: [RouterModule.forChild([]), SharedModule],
})
export class CoreModule {}
