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
      .set('TimeSort', dto.TimeSort)
      .set('AlarmSort', dto.AlarmSort)
      .set('FromTime', dto.FromTime)
      .set('UntilTime', dto.UntilTime);

    return this.http.get('report/alarms-timespan', { params: params });
  }

  getAllAlarmsOfPriority(dto: TimeSortAndAlarmPriorityDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.TimeSort)
      .set('AlarmSort', dto.AlarmPriority)

    return this.http.get('report/alarms-priority', { params: params });
  }

  getAllTagValuesInTimeSpan(dto: TimeSortWithTimeSpanDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.TimeSort)
      .set('FromTime', dto.FromTime)
      .set('UntilTime', dto.UntilTime)

    return this.http.get('report/tag-values-timespan', { params: params });
  }

  getAllLastValuesForAnalogInputs(dto: TimeSortReportDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.TimeSort)

    return this.http.get('report/last-values-analog-inputs', { params: params });
  }


  getAllLastValuesForDigitalInputs(dto: TimeSortReportDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.TimeSort)

    return this.http.get('report/last-values-digital-inputs', { params: params });
  }

  getAllTagValuesForTag(tagId: number, dto: TimeSortReportDTO): Observable<any> {
    let params = new HttpParams()
      .set('TimeSort', dto.TimeSort)

    return this.http.get('report/tag-values-' + tagId, { params: params });
  }

}

export interface TimeSortAndAlarmSortWithTimeSpanDTO{
  TimeSort: string,
  AlarmSort: string,
  FromTime: string,
  UntilTime: string
}

export interface TimeSortAndAlarmPriorityDTO{
  TimeSort: string,
  AlarmPriority: string
}

export interface TimeSortWithTimeSpanDTO{
  TimeSort: string,
  FromTime: string,
  UntilTime: string
}

export interface TimeSortReportDTO{
  TimeSort: string
}