import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
