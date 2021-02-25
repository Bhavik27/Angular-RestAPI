import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class CoreService {
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

    set UserAccess(value: string) {
        localStorage.setItem("UserAccess", value)
    }
    get UserAccess() {
        return localStorage.getItem("UserAccess")
    }

}