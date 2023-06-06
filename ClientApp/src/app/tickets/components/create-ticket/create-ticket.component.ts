import { TicketsService } from './../../tickets.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.css'],
})
export class CreateTicketComponent {
  ticketForm: FormGroup;
  constructor(
    private _fb: FormBuilder,
    private ticketService: TicketsService,
    private router: Router
  ) {
    this.ticketForm = this._fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  onFormSubmit() {
    if (this.ticketForm.valid) {
      this.ticketService.create(this.ticketForm.value, 'create').subscribe({
        next: (value: any) => {
          this.router.navigateByUrl('tickets');
          console.log(value);
        },
        error: (err: any) => {
          console.log(err);
        },
      });
    }
  }
}
