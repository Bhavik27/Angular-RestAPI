import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-activity-log',
  templateUrl: './activity-log.component.html',
  styleUrls: ['./activity-log.component.css']
})
export class ActivityLogComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router) {
    if (!authService.hasAccess("ActivityLog", "ViewAccess"))
      router.navigate(["/Dashboard"])

  }

  ngOnInit(): void {
  }

}
