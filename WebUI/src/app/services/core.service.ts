import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CoreService {
    public Title = new Subject<string>();

    set Token(value: string) {
        localStorage.setItem("Token", value)
    }
    get Token() {
        return localStorage.getItem("Token")
    }

    set RoleID(value: string) {
        localStorage.setItem("RoleID", value)
    }
    get RoleID() {
        return localStorage.getItem("RoleID")
    }

    set UserName(value: string) {
        localStorage.setItem("UserName", value)
    }
    get UserName() {
        return localStorage.getItem("UserName")
    }

    setPageTitle(value: string) {
        this.Title.next(value);
    }
    get PageTitle() {
        return this.Title.asObservable();
    }


}