import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { CoreService } from '../services/core.service';
import { ActivityLog } from '../shared/activity.model';
import { PageModel } from '../shared/page.model';

@Component({
  selector: 'app-activity-log',
  templateUrl: './activity-log.component.html',
  styleUrls: ['./activity-log.component.css']
})
export class ActivityLogComponent implements OnInit {

  activity: ActivityLog[];
  pageModel = new PageModel();
  panelOpenState: boolean[];

  constructor(private authService: AuthService,
    private apiService: ApiService,
    private router: Router,
    private coreService: CoreService) {
    if (!authService.hasAccess("ActivityLog", "ViewAccess"))
      router.navigate(["/Dashboard"])
    this.coreService.setPageTitle("ActivityLog")
  }

  ngOnInit(): void {
    this.activity = [];
    this.panelOpenState = [];
    this.pageModel.PageIndex = 0;
    this.pageModel.PageSize = 10;
    this.pageModel.OrderBy = "ActivityTime";
    this.pageModel.SortOrder = "desc";
    this.getActivityLogs();
  }

  onPageChange(page: PageEvent) {
    this.pageModel.PageIndex = page.pageIndex;
    this.pageModel.PageSize = page.pageSize;
    this.getActivityLogs();
  }

  getActivityLogs() {
    this.apiService.post('api/Master/GetActivityLogs', this.pageModel)
      .subscribe(data => {
        this.pageModel.Length = data[0].totalRecords;
        this.activity = this.convertToModel(data);
        for (var i = 0; i < this.pageModel.Length; i++) {
          this.panelOpenState.push(false)
        }
      })
  }

  convertToModel(value: any): ActivityLog[] {
    const data = [];
    if (value != null || value.length != 0) {
      for (var v of value) {
        data.push({
          ActivityLogId: v.ActivityLogId,
          ActivityOn: v.activityOn,
          ActivityType: v.activityType,
          ActivityByName: v.activityByName,
          ActivityTime: v.activityTime,
          ActivityFor: v.activityFor,
          TotalRecords: v.totalRecords,
        });
      }
    }
    return data;
  }

}
