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

  user = new UserModel();
  userForm: FormGroup;
  constructor(public dialogRef: MatDialogRef<EditUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private apiService: ApiService) { }

  ngOnInit(): void {
    if (this.data.UserId != 0) {
      this.user.UserId = this.data.UserId;
      this.user.UserName = this.data.UserName;
      this.user.FirstName = this.data.FirstName;
      this.user.LastName = this.data.LastName;
      this.user.DateOfBirth = this.data.DateOfBirth;
      this.user.Gender = this.data.Gender;
      this.user.MailId = this.data.MailId;
    }

    this.userForm = new FormGroup({
      UserName: new FormControl(''),
      FirstName: new FormControl(''),
      LastName: new FormControl(''),
      DateOfBirth: new FormControl(''),
      Gender: new FormControl(''),
      MailId: new FormControl(''),
    })
  }

  onClickSave() {
    this.apiService.post('api/User/SaveUser', this.user)
      .subscribe(data => {
        console.log(data);
        this.dialogRef.close(1)
      });
  }

  onNoClick() {
    this.dialogRef.close(0)
  }

}
