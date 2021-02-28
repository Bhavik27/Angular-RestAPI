import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { UserLoginModel } from '../shared/user.model';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  userLogin = new UserLoginModel();
  userLoginForm: FormGroup;
  errorMessage: string;
  constructor(private apiService: ApiService,
    private authService:AuthService,
    private _router: Router) { }

  ngOnInit(): void {
    this.userLoginForm = new FormGroup({
      UserNameControl: new FormControl(''),
      PasswordControl: new FormControl('')
    })
  }

  onUserLogin() {
    this.apiService.post('api/User/Authenticate', this.userLogin)
      .subscribe(data => {
        if (data == 0) {
          this.errorMessage = "User Not Found"
        }
        else if (data == -1) {
          this.errorMessage = "Incorrect UserName and Password"
        }
        else {
          this.errorMessage = null;
          this.authService.Authenticate(data);
        }
      },
        (err) => {
          console.log(err);
        },
        () => {
          setTimeout(() => {
            this.errorMessage = ""
          }, 3000)
        });
  }


}
