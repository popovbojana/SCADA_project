import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginCredentialsDTO, UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private userService: UserService,private router: Router) { }

  login() {
    const userCredentials: LoginCredentialsDTO = {
      Username: this.username,
      Password: this.password
    }

    this.userService.login(userCredentials).subscribe((response) => {
      alert(response.message);
      this.router.navigate(['trending']);
    },
    (error) => {
      alert(error.error.message);
    }
    );

  }
}
