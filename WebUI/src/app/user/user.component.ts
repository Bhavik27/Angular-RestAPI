import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ConfirmBoxComponent } from '../main/confirm-box/confirm-box.component';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { CoreService } from '../services/core.service';
import { PageModel } from '../shared/page.model';
import { UserModel } from '../shared/user.model';
import { EditUserComponent } from './edit-user/edit-user.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  createAccess: boolean = false;
  updateAccess: boolean = false;
  deleteAccess: boolean = false;

  user: UserModel[];
  pageModel = new PageModel();
  displayColumns: string[] = ['UserName', 'FirstName', 'LastName', 'DateOfBirth', 'Gender', 'MailId', 'Action'];
  constructor(private apiService: ApiService,
    public dialog: MatDialog,
    private authService: AuthService,
    private router: Router,
    private coreService: CoreService) {
    if (!authService.hasAccess("UserMaster", "ViewAccess")) {
      router.navigate(["/Dashboard"])
    }
    this.coreService.setPageTitle("UserMaster")
  }

  ngOnInit(): void {
    this.user = [];
    this.pageModel.PageIndex = 0;
    this.pageModel.PageSize = 5;
    this.pageModel.OrderBy = "UserName";
    this.pageModel.SortOrder = "asc";
    this.createAccess = this.authService.hasAccess("UserMaster", "CreateAccess");
    this.updateAccess = this.authService.hasAccess("UserMaster", "UpdateAccess");
    this.deleteAccess = this.authService.hasAccess("UserMaster", "DeleteAccess");
    this.getUsers();
  }

  onSortChange(sort:Sort){
    this.pageModel.OrderBy = sort.active;
    this.pageModel.SortOrder = sort.direction;
    this.getUsers();
  }

  onPageChange(page:PageEvent){
    this.pageModel.PageIndex = page.pageIndex;
    this.pageModel.PageSize = page.pageSize;
    this.getUsers();
  }

  getUsers() {
    this.apiService.post('api/User/GetUsers',this.pageModel)
      .subscribe(data => {
        this.pageModel.Length = data[0].totalRecords;
        this.user = this.convertToModel(data);
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

  onDelete(id: number) {
    this.dialog.open(ConfirmBoxComponent, {
      width: '400px',
    })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.apiService.delete(`api/User/DeleteUser/${id}`)
            .subscribe(data => {
              console.log('record deleted of ' + id);
              this.getUsers();
            });
        }
      });
  }

  onAdd() {
    this.dialog.open(EditUserComponent,
      {
        width: '800px',
        data: { userId: 0 }
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.getUsers();
        }
      });
  }

  onEdit(user: any) {
    this.dialog.open(EditUserComponent,
      {
        width: '800px',
        data: user
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.getUsers();
        }
      });
  }

}
