import { Injectable } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MatDialogConfig,
} from '@angular/material/dialog';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  private dialogRef!: MatDialogRef<any> | undefined;

  constructor(private dialog: MatDialog) {}

  openDialog(
    component: any,
    config?: MatDialogConfig
  ): Observable<any> {
    const dialogConfig: MatDialogConfig = config || {}; // Use supplied config or empty object as default

    this.dialogRef = this.dialog.open(component, dialogConfig);

    return this.dialogRef.afterClosed();
  }

  closeDialog(): void {
    if (this.dialogRef) {
      this.dialogRef.close();
      this.dialogRef = undefined;
    }
  }
}