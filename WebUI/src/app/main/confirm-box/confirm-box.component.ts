import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-box',
  templateUrl: './confirm-box.component.html',
  styleUrls: ['./confirm-box.component.css']
})
export class ConfirmBoxComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ConfirmBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  OnClickYes() {
    this.dialogRef.close(1)
  }

  onNoClick() {
    this.dialogRef.close(0)
  }

}
