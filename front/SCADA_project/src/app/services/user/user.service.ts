import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user$ = new BehaviorSubject(null);
  userState$ = this.user$.asObservable();

  constructor(private http: HttpClient) { 
    this.user$.next(this.getRole());
  }

  getRole(): any {
    if (this.isLoggedIn()) {
      const role: string = localStorage.getItem('user')!; 
      return role;
    }
    return null;
  }

  isLoggedIn(): boolean {
    if (localStorage.getItem('user') != null) {
      return true;
    }
    return false;
  }

  setUser(): void {
    this.user$.next(this.getRole());
  }

  registration(registration: RegisterUserDTO): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'user/registration', registration);
  }

  login(credentials: LoginCredentialsDTO): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'user/login', credentials);
  }

  // logout() {
  //   localStorage.setItem("user", '');
  //   localStorage.setItem("isLoggedIn", "n");
  //   this.isLoggedInSubject.next(false);
  // }

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