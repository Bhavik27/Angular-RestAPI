import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmBoxComponent } from '../main/confirm-box/confirm-box.component';
import { ApiService } from '../services/api.service';
import { UserModel } from '../shared/user.model';
import { EditUserComponent } from './edit-user/edit-user.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  _User: UserModel[];
  displayColumns: string[] = ['UserName', 'FirstName', 'LastName', 'DateOfBirth', 'Gender', 'MailId', 'Action'];
  constructor(private apiService: ApiService,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this._User = [];
    this.GetUsers();
  }

  GetUsers() {
    this.apiService.get('api/Home/GetUsers')
      .subscribe(data => {
        console.log(data);

        this._User.length = data[0].totalRecords;
        this._User = this.convertToModel(data);
      })
  }

  convertToModel(value: any): UserModel[] {
    const data = [];
    if (value != null || value.length != 0) {
      for (var v of value) {
        data.push({
          UserId: v.userId,
          UserName: v.userName,
          FirstName: v.firstName,
          LastName: v.lastName,
          DateOfBirth: v.dateOfBirth,
          Gender: v.gender,
          MailId: v.mailId,
          CreatedBy: v.createdBy,
          CreatedTime: v.createdTime,
          UpdatedBy: v.updatedBy,
          UpdatedTime: v.updatedTime,
        });
      }
    }
    return data;
  }

  OnDelete(id: number) {
    this.dialog.open(ConfirmBoxComponent, {
      width: '400px',
    })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.apiService.delete('api/Home/DeleteUser/' + id)
            .subscribe(data => {
              console.log('record deleted of ' + id);
            });
        }
      });
  }

  OnAdd() {
    this.dialog.open(EditUserComponent,
      {
        // width: '800px',
        data: { userId: 0 }
      });
  }

  OnEdit(user: any) {
    this.dialog.open(EditUserComponent,
      {
        // width: '800px',
        data: user
      });
  }

}
