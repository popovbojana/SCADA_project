import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isLoggedInSubject = new Subject<boolean>();

  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  constructor(private http: HttpClient) { }

  registration(registration: RegisterUserDTO): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'user/registration', registration);
  }

  login(credentials: LoginCredentialsDTO): Observable<any> {
    this.isLoggedInSubject.next(true);
    localStorage.setItem("user", credentials.Username);
    localStorage.setItem("isLoggedIn", "y");
    return this.http.post<any>(environment.apiHost + 'user/login', credentials);
  }

  logout() {
    localStorage.setItem("user", '');
    localStorage.setItem("isLoggedIn", "n");
    this.isLoggedInSubject.next(false);
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