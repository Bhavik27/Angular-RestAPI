import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { CoreService } from '../services/core.service';

@Component({
  selector: 'app-activity-log',
  templateUrl: './activity-log.component.html',
  styleUrls: ['./activity-log.component.css']
})
export class ActivityLogComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router,
    private coreService: CoreService) {
    if (!authService.hasAccess("ActivityLog", "ViewAccess"))
      router.navigate(["/Dashboard"])
    this.coreService.setPageTitle("ActivityLog")
  }

  ngOnInit(): void {
  }

}
