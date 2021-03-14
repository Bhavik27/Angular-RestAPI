import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { title } from 'process';
import { AuthService } from '../services/auth.service';
import { CoreService } from '../services/core.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  PageTitle: string = ""
  UserMaster: boolean = false;
  RoleMaster: boolean = false;
  ActivityLog: boolean = false;
  open: boolean = true;

  constructor(private authService: AuthService,
    private coreService: CoreService,
    private router:Router) {
    coreService.PageTitle.subscribe(title => { this.PageTitle = title })
    // debugger
    this.UserMaster = this.authService.hasAccess("UserMaster", "ViewAccess")
    this.RoleMaster = this.authService.hasAccess("RoleMaster", "ViewAccess")
    this.ActivityLog = this.authService.hasAccess("ActivityLog", "ViewAccess")
  }

  ngOnInit(): void {

  }

  onLogout(){
    localStorage.clear();
    this.router.navigate(['/Login']);
  }

}
