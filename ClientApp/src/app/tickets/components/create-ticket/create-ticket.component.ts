import { TicketsService } from './../../tickets.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogService } from 'shared/services/dialog.service';
import { Ticket } from 'shared/models/Ticket';

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
    private snackBar: MatSnackBar,
    public dialog: DialogService
  ) {
    this.ticketForm = this._fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  onFormSubmit() {
    if (this.ticketForm.valid) {
      this.ticketService.create(this.ticketForm.value, 'create').subscribe({
        next: (ticketId: Ticket) => {
          this.dialog.closeDialog();
          this.snackBar.open('Ticket created successfully!', 'Done');
          console.log(ticketId);
        },
        error: (err: any) => {
          console.log(err);
        },
      });
    }
  }
}
