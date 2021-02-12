import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styleUrls: ['./edit-role.component.css']
})
export class EditRoleComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<EditRoleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private apiService: ApiService) { }

  ngOnInit(): void {
  }

  OnClickSave() {
    this.dialogRef.close(1)
  }

  onNoClick() {
    this.dialogRef.close(0)
  }

}
