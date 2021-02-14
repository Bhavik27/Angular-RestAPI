import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from 'src/app/services/api.service';
import { UserModel } from 'src/app/shared/user.model';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  _User = new UserModel();
  _UserForm: FormGroup;
  constructor(public dialogRef: MatDialogRef<EditUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private apiService: ApiService) { }

  ngOnInit(): void {
    if (this.data.UserId != 0) {
      this._User.UserId = this.data.UserId;
      this._User.UserName = this.data.UserName;
      this._User.FirstName = this.data.FirstName;
      this._User.LastName = this.data.LastName;
      this._User.DateOfBirth = this.data.DateOfBirth;
      this._User.Gender = this.data.Gender;
      this._User.MailId = this.data.MailId;
    }

    this._UserForm = new FormGroup({
      UserName: new FormControl(''),
      FirstName: new FormControl(''),
      LastName: new FormControl(''),
      DateOfBirth: new FormControl(''),
      Gender: new FormControl(''),
      MailId: new FormControl(''),
    })
  }

  OnClickSave() {
    this.apiService.post('api/User/SaveUser', this._User)
      .subscribe(data => {
        console.log(data);
        this.dialogRef.close(1)
      });
  }

  onNoClick() {
    this.dialogRef.close(0)
  }

}
