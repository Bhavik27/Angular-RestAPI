import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';
import { CoreService } from 'src/app/services/core.service';
import { ModuleMappingModel } from 'src/app/shared/module.model';

@Component({
  selector: 'app-module-mapping',
  templateUrl: './module-mapping.component.html',
  styleUrls: ['./module-mapping.component.css']
})
export class ModuleMappingComponent implements OnInit {

  UpdateAccess: boolean = false;

  _ModuleMappingModel: ModuleMappingModel[];
  displayColumns: string[] = ["Module", "View", "Create", "Update", "Delete"]
  RoleId: number;
  NotificationMessage: string = "";
  constructor(private _Activatedroute: ActivatedRoute,
    private apiService: ApiService,
    private router: Router,
    private authService: AuthService,
    private coreService: CoreService) {
    if (!authService.hasAccess("ModuleMapping", "ViewAccess")) {
      router.navigate(["/Dashboard"])
    }
    this.coreService.setPageTitle("ModuleMapping")
  }

  ngOnInit(): void {
    this._ModuleMappingModel = [];
    this.UpdateAccess = this.authService.hasAccess("ModuleMapping", "UpdateAccess");
    this._Activatedroute.paramMap.subscribe(params => {
      this.RoleId = parseInt(params.get('id'));
    });
    this.GeteRoleRights(this.RoleId)

  }

  GeteRoleRights(RoleId: number) {
    this.apiService.get('api/Master/GeteRoleRights/' + RoleId)
      .subscribe(
        data => {
          this._ModuleMappingModel = this.convertToModel(data)
          if (this._ModuleMappingModel.length <= 0) {
            this.NotificationMessage = "Please Contact DB Administrator"
          }
        },
        err => console.log(err)
      )
  }

  convertToModel(value: any): ModuleMappingModel[] {
    const data = [];
    if (value != null || value.length != 0) {
      for (var v of value) {
        data.push({
          RoleId: v.roleId,
          RoleAccessId: v.roleAccessId,
          ModuleName: v.moduleName,
          ViewAccess: v.viewAccess ? true : false,
          CreateAccess: v.createAccess ? true : false,
          UpdateAccess: v.updateAccess ? true : false,
          DeleteAccess: v.deleteAccess ? true : false,
          IsView: v.isView ? true : false,
          IsCreate: v.isCreate ? true : false,
          IsUpdate: v.isUpdate ? true : false,
          IsDelete: v.isDelete ? true : false,
        });
      }
    }
    return data;
  }

  OnSave() {
    for (var item of this._ModuleMappingModel) {
      item.ViewAccess = item.ViewAccess ? 1 : 0;
      item.CreateAccess = item.CreateAccess ? 1 : 0;
      item.UpdateAccess = item.UpdateAccess ? 1 : 0;
      item.DeleteAccess = item.DeleteAccess ? 1 : 0;
      item.IsView = item.IsView ? 1 : 0;
      item.IsCreate = item.IsCreate ? 1 : 0;
      item.IsUpdate = item.IsUpdate ? 1 : 0;
      item.IsDelete = item.IsDelete ? 1 : 0;
    }

    this.apiService.post('api/Master/SetRoleRights/' + this.RoleId, this._ModuleMappingModel,)
      .subscribe(
        data => {
          if (this.coreService.RoleID == this.RoleId.toString()) {
            this.authService.GeteRoleRights(this.RoleId);
          }
        },
        err => {
          console.log(err);
        },
        () => this.router.navigate(['/RoleManager'])
      );

  }

  OnCancel() {
    this.router.navigate(['/RoleManager']);
  }

}
