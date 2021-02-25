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

  _UserLogin = new UserLoginModel();
  _UserLoginForm: FormGroup;
  _ErrorMessage: string;
  constructor(private apiService: ApiService,
    private authService:AuthService,
    private _router: Router) { }

  ngOnInit(): void {
    this._UserLoginForm = new FormGroup({
      UserNameControl: new FormControl(''),
      PasswordControl: new FormControl('')
    })
  }

  OnUserLogin() {
    this.apiService.post('api/User/Authenticate', this._UserLogin)
      .subscribe(data => {
        if (data == 0) {
          this._ErrorMessage = "User Not Found"
        }
        else if (data == -1) {
          this._ErrorMessage = "Incorrect UserName and Password"
        }
        else {
          this._ErrorMessage = null;
          this.authService.Authenticate(data);
          this._router.navigate(['/Dashboard'])
        }
      },
        (err) => {
          console.log(err);
        },
        () => {
          setTimeout(() => {
            this._ErrorMessage = ""
          }, 3000)
        });
  }


}
