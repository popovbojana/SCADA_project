import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  registration(registration: RegisterUserDTO): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'user/registration', registration);
  }

  login(credentials: LoginCredentialsDTO): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'user/login', credentials);
  }

}

export interface LoginCredentialsDTO{
  Username: string,
  Password: string
}

export interface User{
  Id: number,
  Name: string,
  Surname: string,
  Username: string,
  Password: string
}

export interface RegisterUserDTO{
  Name: string;
  Surname: string,
  Username: string,
  Password: string
}