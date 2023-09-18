import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class AlarmService {

  constructor(private http: HttpClient) { }

  addAlarm(alarm: Alarm): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'alarm/add-alarm', alarm);
  }

  removeAlarm(alarmId: number): Observable<any> {
    return this.http.delete<any>(environment.apiHost + 'alarm/remove-alarm-' + alarmId);
  }

  getAllAlarms(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'alarm');
  }
}

export interface Alarm{
  id?: number,
  value: number,
  tagId: number,
  type: string,
  priority: string
}