import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { CoreService } from '../services/core.service';
import { UserModel } from '../shared/user.model';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user = new UserModel();
  userProfileForm: FormGroup;
  constructor(private apiService: ApiService,
    private router: Router,
    private coreService: CoreService) {
    this.coreService.setPageTitle("UserProfile")
  }

  ngOnInit(): void {
    this.userProfileForm = new FormGroup({
      UserName: new FormControl(''),
      FirstName: new FormControl(''),
      LastName: new FormControl(''),
      DateOfBirth: new FormControl(''),
      Gender: new FormControl(''),
      MailId: new FormControl(''),
    })
    this.GetProfileData();
  }

  GetProfileData() {
    this.apiService.get('api/User/ProfileData')
      .subscribe(
        data => {
          this.user.DateOfBirth = data.dateOfBirth;
          this.user.FirstName = data.firstName;
          this.user.Gender = data.gender;
          this.user.isActive = data.isActive;
          this.user.LastName = data.lastName;
          this.user.MailId = data.mailId;
          this.user.UserName = data.userName;
          this.user.UserId = data.userId;
          this.user.Role = data.role;
        },
        err => {
          console.log(err);
        });
  }

  onClickSave() {
    this.apiService.post('api/User/UpdateProfile', this.user)
      .subscribe(
        data => {
          console.log(data);
        },
        err => {
          console.log(err);
        }, () => {
          this.router.navigate(["/Dashboard"])
        });
  }

}
