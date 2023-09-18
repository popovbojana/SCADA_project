import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  role: string = 'notLoggedIn';

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    if(this.userService.isLoggedIn()){
      this.role = 'loggedIn';
    }
  }

  logout() {
    this.role = 'notLoggedIn';
    localStorage.removeItem('user');
    this.userService.setUser();
    this.router.navigate(['login']);
  }

}
