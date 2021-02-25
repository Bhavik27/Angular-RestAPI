import { Injectable } from '@angular/core';
import { ModuleMappingModel } from '../shared/module.model';
import { ApiService } from './api.service';
import { CoreService } from './core.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  _ModuleMappingModel: ModuleMappingModel[];

  constructor(private coreService: CoreService,
    private apiService: ApiService) { }

  public isAuthenticated(): boolean {
    const token = (this.coreService.Token != null) ? true : false;
    return token;
  }

  public Authenticate(RoleID: number) {
    this.coreService.Token = "true"
    this.coreService.RoleID = RoleID.toString()
    this.GeteRoleRights(RoleID)
  }

  GeteRoleRights(RoleId: number) {
    this.apiService.get('api/Master/GeteRoleRights/' + RoleId)
      .subscribe(
        data => {
          this._ModuleMappingModel = this.convertToModel(data)
          if (this._ModuleMappingModel.length > 0) {
            this.coreService.UserAccess = JSON.stringify(data);
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

  hasAccess(ModuleName: string, Type: string) {
    let access = false;
    this._ModuleMappingModel = this.convertToModel(JSON.parse(this.coreService.UserAccess));
    if (this._ModuleMappingModel != null && this._ModuleMappingModel != undefined && this._ModuleMappingModel.length > 0) {
      for (var item of this._ModuleMappingModel) {
        if (item.ModuleName == ModuleName) {
          if (Type == "CreateAccess") { access = Boolean(item.CreateAccess) }
          if (Type == "UpdateAccess") { access = Boolean(item.UpdateAccess) }
          if (Type == "DeleteAccess") { access = Boolean(item.DeleteAccess) }
          if (Type == "ViewAccess") { access = Boolean(item.ViewAccess) }
        }
      }
    }
    return access;
  }

}
