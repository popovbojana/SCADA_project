import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Alarm, AlarmActivation } from 'src/app/services/alarm/alarm.service';
import { ReportService, TimeSortAndAlarmSortWithTimeSpanDTO } from 'src/app/services/report/report.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent {
    selectedReportType: string = '';
    sortOrder: string = 'asc';
    dateFrom: string = '';
    dateTo: string = '';

    reportData: any[] = [];

    constructor(private reportService: ReportService, private router: Router) { }

    //report1
    timeSortR1: string = 'Asc';
    alarmSortR1: string = 'Asc';
    fromTimeR1: string = '';
    untilTimeR1: string = '';
    report1Data: AlarmActivation[] = [];
    showDataR1: boolean = false;

    generateReport() {
      if(this.selectedReportType === 'alarms-timespan'){
        this.showDataR1 = true;
        const dto: TimeSortAndAlarmSortWithTimeSpanDTO = {
          TimeSort: this.timeSortR1,
          AlarmSort: this.alarmSortR1,
          FromTime: this.fromTimeR1,
          UntilTime: this.untilTimeR1
        }
        this.reportService.getAllAlarmsInTimespan(dto).subscribe((response) => {
          for (let element of response){
            const alarm: AlarmActivation = {
              id: element.id,
              timestamp: element.timestamp,
              alarmId: element.alarmId
            }
            this.report1Data.push(alarm);
          }
          console.log(response);
        });
      } else if(this.selectedReportType === 'alarms-priority'){

      } else if(this.selectedReportType === 'tag-values-timespan'){

      } else if(this.selectedReportType === 'last-values-analog-inputs'){

      } else if(this.selectedReportType === 'last-values-digital-inputs'){

      } else {

      }
    }
}
