import { Component, OnInit, ViewChild } from '@angular/core';
import { ApexChart, ApexNonAxisChartSeries, ApexResponsive, ChartComponent } from 'ng-apexcharts';
import { ApiService } from '../services/api.service';
import { DashBoardModel } from '../shared/dashboard.model';

export type ChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  responsive: ApexResponsive[];
  labels: any;
};

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  @ViewChild("chart", { static: false }) chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;
  _dashBoard = new DashBoardModel();


  constructor(private apiService: ApiService) {
    this.LoadChartData(this._dashBoard)
  }

  LoadChartData(data: DashBoardModel) {
    this.chartOptions = {
      series: [data.Male, data.Female, data.Other],
      chart: {
        width: 380,
        type: "pie"
      },
      labels: ["Male", "Female", "Other"],
      responsive: [
        {
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: "bottom"
            }
          }
        }
      ]
    };
  }

  ngOnInit(): void {
    this.GetChartData()
  }

  GetChartData() {
    this.apiService.get('api/DashBoard/GetChartData')
      .subscribe(
        data => {
          this._dashBoard.Male = data.male;
          this._dashBoard.Female = data.female;
          this._dashBoard.Other = data.other;
        },
        err => console.log(err),
        () => {
          this.LoadChartData(this._dashBoard)
        }
      )
  }

}
