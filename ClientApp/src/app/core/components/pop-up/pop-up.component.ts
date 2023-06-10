import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-pop-up',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.css'],
})
export class PopUpComponent implements OnInit {
  input?: { title: string; content: string; submit: () => void };
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private ref?: MatDialogRef<PopUpComponent>
  ) {}

  ngOnInit(): void {
    this.input = this.data;
  }
  onSubmit() {
    this.input?.submit();
    this.ref?.close();
    this.ref = undefined;
  }
}
