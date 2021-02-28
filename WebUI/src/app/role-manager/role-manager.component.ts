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
import { RoleRequestModel } from '../shared/role.model';
import { EditRoleComponent } from './edit-role/edit-role.component';

@Component({
  selector: 'app-role-manager',
  templateUrl: './role-manager.component.html',
  styleUrls: ['./role-manager.component.css']
})
export class RoleManagerComponent implements OnInit {

  CreateAccess: boolean = false;
  UpdateAccess: boolean = false;
  ManageAccess: boolean = false;

  role: RoleRequestModel[];
  pageModel = new PageModel();
  displayColumns: string[] = ['RoleName', 'Action'];
  constructor(private apiService: ApiService,
    public dialog: MatDialog,
    public router: Router,
    private authService: AuthService,
    private coreService: CoreService) {
    if (!authService.hasAccess("RoleMaster", "ViewAccess")) {
      router.navigate(["/Dashboard"])
    }
    this.coreService.setPageTitle("RoleManager")
  }

  ngOnInit(): void {
    this.role = [];
    this.pageModel.PageIndex = 0;
    this.pageModel.PageSize = 5;
    this.pageModel.OrderBy = "RoleName";
    this.pageModel.SortOrder = "asc";
    this.CreateAccess = this.authService.hasAccess("RoleMaster", "CreateAccess");
    this.UpdateAccess = this.authService.hasAccess("RoleMaster", "UpdateAccess");
    this.ManageAccess = this.authService.hasAccess("ModuleMapping", "ViewAccess");
    this.getRoles();
  }

  onSortChange(sort:Sort){
    this.pageModel.OrderBy = sort.active;
    this.pageModel.SortOrder = sort.direction;
    this.getRoles();
  }

  onPageChange(page:PageEvent){
    this.pageModel.PageIndex = page.pageIndex;
    this.pageModel.PageSize = page.pageSize;
    this.getRoles();
  }

  getRoles() {
    this.apiService.post('api/Master/GetRoles',this.pageModel)
      .subscribe(data => {
        this.pageModel.Length = data[0].totalRecords;
        this.role = this.convertToModel(data);
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

  onAdd() {
    this.dialog.open(EditRoleComponent,
      {
        width: '800px',
        data: { roleId: 0 }
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.getRoles();
        }
      });
  }

  onEdit(role: any) {
    this.dialog.open(EditRoleComponent,
      {
        width: '800px',
        data: role
      })
      .afterClosed()
      .subscribe(result => {
        if (result == 1) {
          this.getRoles();
        }
      });
  }

  getManualMapping(id: number) {
    this.router.navigate(['/ModuleMapping', id])
  }

}
