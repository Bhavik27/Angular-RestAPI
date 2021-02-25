import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  IsAuthenticate: boolean = false;

  constructor(private _Router: Router,
    private authService: AuthService) {

  }
  ngOnInit(): void {
    if (this._Router.url == "/" && this.authService.isAuthenticated()) {
      this.IsAuthenticate = true;
      this._Router.navigate(['Dashboard'])
    }
    else {
      this.IsAuthenticate = false;
    }
  }


}
