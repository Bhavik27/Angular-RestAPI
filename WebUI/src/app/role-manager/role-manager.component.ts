import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmBoxComponent } from '../main/confirm-box/confirm-box.component';
import { ApiService } from '../services/api.service';
import { RoleModel } from '../shared/role.model';
import { EditRoleComponent } from './edit-role/edit-role.component';

@Component({
  selector: 'app-role-manager',
  templateUrl: './role-manager.component.html',
  styleUrls: ['./role-manager.component.css']
})
export class RoleManagerComponent implements OnInit {

  _Role: RoleModel[];
  // displayColumns: string[] = ['RoleId','Role'];
  displayColumns: string[] = ['Role','Action'];
  constructor(private apiService: ApiService,
    public dialog: MatDialog) { }


  ngOnInit(): void {
    this._Role = [];
    this.GetUsers();
  }

  GetUsers() {
    this.apiService.get('api/Master/GetRoles')
      .subscribe(data => {
        this._Role.length = data[0].totalRecords;
        this._Role = this.convertToModel(data);
      })
  }

  convertToModel(value: any): RoleModel[] {
    const data = [];
    if (value != null || value.length != 0) {
      for (var v of value) {
        data.push({
          RoleId: v.roleId,
          Role: v.role,
          ViewAccess: v.viewAccess,
          InsertAccess: v.insertAccess,
          EditAccess: v.editAccess,
          DeleteAccess: v.deleteAccess,
          CreatedBy: v.createdBy,
          CreatedTime: v.createdTime,
          UpdatedBy: v.updatedBy,
          UpdatedTime: v.updatedTime,
        });
      }
    }
    return data;
  }

  OnAdd() {
    this.dialog.open(EditRoleComponent,
      {
        width: '800px',
        data: { userId: 0 }
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.GetUsers();
        }
      });
  }

  OnEdit(user: any) {
    this.dialog.open(EditRoleComponent,
      {
        width: '800px',
        data: user
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.GetUsers();
        }
      });
  }

}
