import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ModuleMappingModel } from '../shared/module.model';
import { UserLoginReponseModel } from '../shared/user.model';
import { ApiService } from './api.service';
import { CoreService } from './core.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  _ModuleMappingModel: ModuleMappingModel[];

  set UserAccess(value: ModuleMappingModel[]) {
    localStorage.setItem("UserAccess", JSON.stringify(value))
  }
  get UserAccess(): ModuleMappingModel[] {
    return JSON.parse(localStorage.getItem("UserAccess"))
  }

  constructor(private coreService: CoreService,
    private apiService: ApiService,
    private _router: Router) { }

  public isAuthenticated(): boolean {
    const token = (this.coreService.Token != null) ? true : false;
    return token;
  }

  public Authenticate(userLoginReponse: UserLoginReponseModel) {
    this.coreService.Token = userLoginReponse.token
    this.coreService.UserName = userLoginReponse.userName
    this.coreService.RoleID = userLoginReponse.roleID.toString()
    this.GeteRoleRights(userLoginReponse.roleID)
    this.expireToken()
  }

  GeteRoleRights(RoleId: number) {
    this.apiService.get('api/Master/GeteRoleRights/' + RoleId)
      .subscribe(
        data => {
          this.UserAccess = this.convertToModel(data)
          if (this.hasAccess("Dashboard", "ViewAccess")) {
            this._router.navigate(['/Dashboard'])
          }
        },
        err => console.log(err)
      )
  }

  convertToModel(value: any): ModuleMappingModel[] {
    const data = [];
    // debugger
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

    if (this.UserAccess != null && this.UserAccess != undefined && this.UserAccess.length > 0) {
      for (var item of this.UserAccess) {
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

  expireToken() {
    const EXPIRE_TIME = 1000 * 60 * 60 * 24;
    setTimeout(function () {
      localStorage.clear();
    }, EXPIRE_TIME);
  }


}
