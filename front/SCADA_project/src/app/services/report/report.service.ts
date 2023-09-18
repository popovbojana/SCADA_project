import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http: HttpClient) { }

  getAllAlarmsInTimespan(dto: TimeSortAndAlarmSortWithTimeSpanDTO): Observable<any> {
    let params = new HttpParams()
      .set('timeSort', dto.timeSort)
      .set('alarmSort', dto.alarmSort)
      .set('fromTime', dto.fromTime)
      .set('untilTime', dto.untilTime);

    return this.http.get<any>(environment.apiHost +'report/alarms-timespan', { params: params });
  }

  getAllAlarmsOfPriority(dto: TimeSortAndAlarmPriorityDTO): Observable<any> {
    let params = new HttpParams()
      .set('timeSort', dto.timeSort)
      .set('alarmSort', dto.alarmPriority)

    return this.http.get('report/alarms-priority', { params: params });
  }

  getAllTagValuesInTimeSpan(dto: TimeSortWithTimeSpanDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.timeSort)
      .set('FromTime', dto.fromTime)
      .set('UntilTime', dto.untilTime)

    return this.http.get('report/tag-values-timespan', { params: params });
  }

  getAllLastValuesForAnalogInputs(dto: TimeSortReportDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.timeSort)

    return this.http.get('report/last-values-analog-inputs', { params: params });
  }


  getAllLastValuesForDigitalInputs(dto: TimeSortReportDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.timeSort)

    return this.http.get('report/last-values-digital-inputs', { params: params });
  }

  getAllTagValuesForTag(tagId: number, dto: TimeSortReportDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.timeSort)

    return this.http.get('report/tag-values-' + tagId, { params: params });
  }

}

export interface TimeSortAndAlarmSortWithTimeSpanDTO{
  timeSort: string,
  alarmSort: string,
  fromTime: string,
  untilTime: string
}

export interface TimeSortAndAlarmPriorityDTO{
  timeSort: string,
  alarmPriority: string
}

export interface TimeSortWithTimeSpanDTO{
  timeSort: string,
  fromTime: string,
  untilTime: string
}

export interface TimeSortReportDTO{
  timeSort: string
}