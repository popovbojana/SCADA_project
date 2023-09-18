import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Alarm, AlarmActivation } from 'src/app/services/alarm/alarm.service';
import { ReportService, TimeSortAndAlarmPriorityDTO, TimeSortAndAlarmSortWithTimeSpanDTO, TimeSortReportDTO, TimeSortWithTimeSpanDTO } from 'src/app/services/report/report.service';
import { TagValue } from 'src/app/services/tag/tag.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent {
    selectedReportType: string = '';
    showReportType: boolean = true;

    constructor(private reportService: ReportService, private router: Router) { }

    //report1
    timeSortR1: string = 'Asc';
    alarmSortR1: string = 'Asc';
    fromTimeR1: string = '';
    untilTimeR1: string = '';
    report1Data: AlarmActivation[] = [];
    showDataR1: boolean = false;
    showFormR1: boolean = true;

    //report2
    timeSortR2: string = 'Asc';
    alarmpriorityR2: string = 'Low';
    report2Data: AlarmActivation[] = [];
    showDataR2: boolean = false;
    showFormR2: boolean = true;

    //report3
    timeSortR3: string = 'Asc';
    fromTimeR3: string = '';
    untilTimeR3: string = '';
    report3Data: TagValue[] = [];
    showDataR3: boolean = false;
    showFormR3: boolean = true;

    //report14
    timeSortR4: string = 'Asc';
    report4Data: TagValue[] = [];
    showDataR4: boolean = false;
    showFormR4: boolean = true;

    //report5
    timeSortR5: string = 'Asc';
    report5Data: TagValue[] = [];
    showDataR5: boolean = false;
    showFormR5: boolean = true;

    //report6
    timeSortR6: string = 'Asc';
    tagIdR6: number = 0;
    report6Data: TagValue[] = [];
    showDataR6: boolean = false;
    showFormR6: boolean = true;

    generateReport() {
      if(this.selectedReportType === 'alarms-timespan'){
        this.showDataR1 = true;
        this.showFormR1 = false;
        this.showReportType = false;
        const dto: TimeSortAndAlarmSortWithTimeSpanDTO = {
          timeSort: this.timeSortR1,
          alarmSort: this.alarmSortR1,
          fromTime: this.fromTimeR1,
          untilTime: this.untilTimeR1
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
        this.showDataR2 = true;
        this.showFormR2 = false;
        this.showReportType = false;
        const dto: TimeSortAndAlarmPriorityDTO = {
          timeSort: this.timeSortR2,
          alarmPriority: this.alarmpriorityR2
        }
        this.reportService.getAllAlarmsOfPriority(dto).subscribe((response) => {
          for (let element of response){
            const alarm: AlarmActivation = {
              id: element.id,
              timestamp: element.timestamp,
              alarmId: element.alarmId
            }
            this.report2Data.push(alarm);
          }
          console.log(response);
        });
        } else if(this.selectedReportType === 'tag-values-timespan'){
          this.showDataR3 = true;
          this.showFormR3 = false;
          this.showReportType = false;
          const dto: TimeSortWithTimeSpanDTO = {
            timeSort: this.timeSortR3,
            fromTime: this.fromTimeR3,
            untilTime: this.untilTimeR3
          }
          this.reportService.getAllTagValuesInTimeSpan(dto).subscribe((response) => {
            for (let element of response){
              const tag: TagValue = {
                id: element.id,
                timestamp: element.timestamp,
                value: element.value,
                tagId: element.tagId
              }
              this.report3Data.push(tag);
            }
            console.log(response);
          });
      } else if(this.selectedReportType === 'last-values-analog-inputs'){
        this.showDataR4 = true;
          this.showFormR4 = false;
          this.showReportType = false;
          const dto: TimeSortReportDTO = {
            timeSort: this.timeSortR4
          }
          this.reportService.getAllLastValuesForAnalogInputs(dto).subscribe((response) => {
            for (let element of response){
              const tag: TagValue = {
                id: element.id,
                timestamp: element.timestamp,
                value: element.value,
                tagId: element.tagId
              }
              this.report4Data.push(tag);
            }
            console.log(response);
          });
      } else if(this.selectedReportType === 'last-values-digital-inputs'){
        this.showDataR5 = true;
          this.showFormR5 = false;
          this.showReportType = false;
          const dto: TimeSortReportDTO = {
            timeSort: this.timeSortR4
          }
          this.reportService.getAllLastValuesForDigitalInputs(dto).subscribe((response) => {
            for (let element of response){
              const tag: TagValue = {
                id: element.id,
                timestamp: element.timestamp,
                value: element.value,
                tagId: element.tagId
              }
              this.report5Data.push(tag);
            }
            console.log(response);
          });
      } else {
        this.showDataR6 = true;
          this.showFormR6 = false;
          this.showReportType = false;
          const dto: TimeSortReportDTO = {
            timeSort: this.timeSortR6
          }
          this.reportService.getAllTagValuesForTag(this.tagIdR6, dto).subscribe((response) => {
            for (let element of response){
              const tag: TagValue = {
                id: element.id,
                timestamp: element.timestamp,
                value: element.value,
                tagId: element.tagId
              }
              this.report6Data.push(tag);
            }
            console.log(response);
          });
      }
    }

    refresh(){
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        window.location.reload();
      });
    }
}
