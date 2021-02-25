import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  UserMaster: boolean = false;
  RoleMaster: boolean = false;
  ActivityLog: boolean = false;

  open: boolean = true;
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.UserMaster = this.authService.hasAccess("UserMaster", "ViewAccess")
    this.RoleMaster = this.authService.hasAccess("RoleMaster", "ViewAccess")
    this.ActivityLog = this.authService.hasAccess("ActivityLog", "ViewAccess")
  }

}
