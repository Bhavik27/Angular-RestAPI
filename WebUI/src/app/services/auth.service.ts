import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  public isAuthenticated(): boolean {
    const token = (localStorage.getItem('loginToken') != null) ? true : false;
    return token;
  }

  public Authenticate() {
    localStorage.setItem("loginToken", "logged")
  }
}
