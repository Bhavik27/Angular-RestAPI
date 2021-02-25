import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActivityLogComponent } from './activity-log/activity-log.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ModuleMappingComponent } from './role-manager/module-mapping/module-mapping.component';
import { RoleManagerComponent } from './role-manager/role-manager.component';
import { AuthGuard } from './services/Guard/auth.guard';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {
    path: 'Users',
    component: UserComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'Dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'RoleManager',
    component: RoleManagerComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'Login',
    component: UserLoginComponent
  },
  {
    path: 'ModuleMapping/:id',
    component: ModuleMappingComponent
  },
  {
    path: 'ActivityLog',
    component: ActivityLogComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
