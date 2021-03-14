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

  IsLogin: boolean = true;
  IsForgotPassword: boolean = false;
  IsResetPassword: boolean = false;
  btnName: string;

  userLogin = new UserLoginModel();
  userLoginForm: FormGroup;

  mailID: string;
  otp: number;
  newPassword: string;
  confirmPassword: string;

  errorMessage: string;
  constructor(private apiService: ApiService,
    private authService: AuthService,
    private _router: Router) { }

  ngOnInit(): void {
    this.userLoginForm = new FormGroup({
      UserNameControl: new FormControl(''),
      PasswordControl: new FormControl('')
    })
  }

  onLogin(){
    this.IsResetPassword = false;
    this.IsForgotPassword = false;
    this.IsLogin = true;
  }

  onForgotPassword() {
    this.btnName = "GenerateOTP";
    this.IsForgotPassword = true;
    this.IsLogin = false;
  }

  onResetPassword() {
    this.IsResetPassword = true;
    this.IsForgotPassword = false;
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

  GenerateOTP() {
    if (this.btnName == "GenerateOTP" || this.btnName == "Re-GenerateOTP") {
      this.apiService.post('api/User/GetOTP?MailAddress=' + this.mailID, null)
        .subscribe(data => {
          if (data == 0) {
            this.errorMessage = "User Not Found with this mailid"
          }
          if (data == -1) {
            this.errorMessage = "failure!! please re-generate OTP"
          }
          if (data == 1) {
            this.btnName = "Verify"
            this.errorMessage = null;
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
    else {
      this.apiService.post('api/User/CheckOTP?MailAddress=' + this.mailID + "&OTP=" + this.otp, null)
        .subscribe(data => {
          if (data == 0) {
            this.errorMessage = "OTP not Match"
            this.btnName = "GenerateOTP"
          }
          if (data == 1) {
            this.btnName = "GenerateOTP"
            this.errorMessage = null;
            this.onResetPassword()
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

  ResetPassword() {
    if (this.newPassword != this.confirmPassword) {
      this.errorMessage = "password not match with confirm password"
    }
    else {
      this.apiService.post('api/User/ResetPassword?MailAddress=' + this.mailID + "&newPassword=" + this.confirmPassword, null)
        .subscribe(data => {
          if (data == 0) {
            this.errorMessage = "OTP not Match"
            this.btnName == "GenerateOTP"
          }
          if (data == 1) {
            this.btnName == "GenerateOTP"
            this.errorMessage = null;
            this.onLogin()

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


}
