import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterUserDTO, UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  name: string = '';
  surname: string = '';
  username: string = '';
  password: string = '';

  constructor(private userService: UserService, private router: Router) { }

  register() {
    const newUser: RegisterUserDTO = {
      Name: this.name,
      Surname: this.surname,
      Username: this.username,
      Password: this.password
    }

    this.userService.registration(newUser).subscribe((response) => {
      alert(response.message);
      this.router.navigate(['login']);
    },
    (error) => {
      alert(error.error.message);
    }
    );
  }
}
