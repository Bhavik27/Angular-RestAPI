import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'WebUI';

  constructor(private _Router: Router,
    private authService: AuthService) {

  }
  ngOnInit(): void {
    if (this._Router.url == "/" && this.authService.isAuthenticated())
      this._Router.navigate(['DashBoard'])
    else
      this._Router.navigate(['Login'])

  }


}
