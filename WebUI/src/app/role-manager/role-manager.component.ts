import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmBoxComponent } from '../main/confirm-box/confirm-box.component';
import { ApiService } from '../services/api.service';
import { RoleModel, RoleRequestModel } from '../shared/role.model';
import { EditRoleComponent } from './edit-role/edit-role.component';

@Component({
  selector: 'app-role-manager',
  templateUrl: './role-manager.component.html',
  styleUrls: ['./role-manager.component.css']
})
export class RoleManagerComponent implements OnInit {

  _Role: RoleRequestModel[];
  // displayColumns: string[] = ['RoleId','Role'];
  displayColumns: string[] = ['Role', 'Action'];
  constructor(private apiService: ApiService,
    public dialog: MatDialog) { }


  ngOnInit(): void {
    this._Role = [];
    this.GetRoles();
  }

  GetRoles() {
    this.apiService.get('api/Master/GetRoles')
      .subscribe(data => {
        this._Role.length = data[0].totalRecords;
        this._Role = this.convertToModel(data);
      })
  }

  convertToModel(value: any): RoleRequestModel[] {
    const data = [];
    if (value != null || value.length != 0) {
      for (var v of value) {
        data.push({
          RoleId: v.roleId,
          Role: v.roleName,
          ViewAccess: v.viewAccess,
          InsertAccess: v.insertAccess,
          EditAccess: v.editAccess,
          DeleteAccess: v.deleteAccess,
          CreatedBy: v.createdBy,
          CreatedTime: v.createdTime,
          UpdatedBy: v.updatedBy,
          UpdatedTime: v.updatedTime,
          TotalRecords: v.totalRecords,
        });
      }
    }
    return data;
  }

  OnAdd() {
    this.dialog.open(EditRoleComponent,
      {
        width: '800px',
        data: { roleId: 0 }
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.GetRoles();
        }
      });
  }

  OnEdit(role: any) {
    this.dialog.open(EditRoleComponent,
      {
        width: '800px',
        data: role
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.GetRoles();
        }
      });
  }

}
