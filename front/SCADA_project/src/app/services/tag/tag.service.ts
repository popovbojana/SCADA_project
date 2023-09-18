import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private http: HttpClient) { }

  addAnalogInput(aInput: AnalogInput): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'tag/add-analog-input', aInput);
  }

  addAnalogOutput(aOutput: AnalogOutput): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'tag/add-analog-output', aOutput);
  }

  addDigitalInput(dInput: DigitalInput): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'tag/add-digital-input', dInput);
  }

  addDigitalOutput(dOutput: DigitalOutput): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'tag/add-digital-output', dOutput);
  }

  removeTag(tagId: number): Observable<any> {
    return this.http.delete<any>(environment.apiHost + 'tag/remove-tag-' + tagId);
  }

  turnOnScan(tagId: number): Observable<any> {
    return this.http.put<any>(environment.apiHost + 'tag/scan-on-' + tagId, {});
  }

  turnOffScan(tagId: number): Observable<any> {
    return this.http.put<any>(environment.apiHost + 'tag/scan-off-' + tagId, {});
  }

  getAllTags(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag');
  }

  getAllInputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-inputs');
  }

  getAllOutputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-outputs');
  }

  getAllAnalogInputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-analog-inputs');
  }

  getAllAnalogOutputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-analog-outputs');
  }

  getAllDigitalInputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-digital-inputs');
  }

  getAllDigitalOutputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-digital-outputs');
  }

  getAllOnScanInputs(): Observable<any> {
    return this.http.get<any>(environment.apiHost + 'tag/all-on-scan-inputs');
  }
}

export interface AnalogInput{
  id?: number,
  name: string,
  description: string,
  ioAddress: string,
  value: number,
  scanTime: number,
  isScanOn: boolean,
  lowLimit: number,
  highLimit: number,
  unit: string
}

export interface AnalogOutput{
  id?: number,
  name: string,
  description: string,
  ioAddress: string,
  value: number,
  lowLimit: number,
  highLimit: number
  unit: string
}

export interface DigitalInput{
  id?: number,
  name: string,
  description: string,
  ioAddress: string,
  value: number,
  scanTime: number,
  isScanOn: boolean
}

export interface DigitalOutput{
  id?: number,
  name: string,
  description: string,
  ioAddress: string,
  value: number
}

export interface Tag{
  id: number,
  name: string,
  description: string,
  ioAddress: string,
  value: number
}