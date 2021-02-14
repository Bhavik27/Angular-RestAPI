import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from 'src/app/services/api.service';
import { RoleRequestModel } from 'src/app/shared/role.model';

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styleUrls: ['./edit-role.component.css']
})
export class EditRoleComponent implements OnInit {

  _Role = new RoleRequestModel();
  _RoleForm: FormGroup;
  constructor(public dialogRef: MatDialogRef<EditRoleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private apiService: ApiService) { }

  ngOnInit(): void {
    if (this.data.RoleId != 0) {
      this._Role.RoleId = this.data.RoleId;
      this._Role.RoleName = this.data.Role;
    }
    console.log(this.data);
    

    this._RoleForm = new FormGroup({
      RoleName: new FormControl('')
    })
  }

  OnClickSave() {
    this.apiService.post('api/Master/SaveRoles', this._Role)
      .subscribe(data => {
        console.log(data);
        this.dialogRef.close(1)
      });
  }

  onNoClick() {
    this.dialogRef.close(0)
  }

}
