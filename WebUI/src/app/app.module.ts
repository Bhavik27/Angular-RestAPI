import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainComponent } from './main/main.component';
import { MaterialModule } from './shared/material.module';
import { UserComponent } from './user/user.component';
import { HttpClientModule } from '@angular/common/http';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { ConfirmBoxComponent } from './main/confirm-box/confirm-box.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgApexchartsModule } from 'ng-apexcharts';
import { RoleManagerComponent } from './role-manager/role-manager.component';
import { EditRoleComponent } from './role-manager/edit-role/edit-role.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { ModuleMappingComponent } from './role-manager/module-mapping/module-mapping.component';
import { ActivityLogComponent } from './activity-log/activity-log.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    UserComponent,
    EditUserComponent,
    ConfirmBoxComponent,
    DashboardComponent,
    RoleManagerComponent,
    EditRoleComponent,
    UserLoginComponent,
    ModuleMappingComponent,
    ActivityLogComponent,
    UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgApexchartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
