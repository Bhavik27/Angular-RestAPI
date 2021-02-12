import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RoleManagerComponent } from './role-manager/role-manager.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {
    path: 'Users',
    component: UserComponent
  },
  {
    path: 'Dashboard',
    component: DashboardComponent
  },
  {
    path: 'RoleManager',
    component: RoleManagerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
