
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class AuthService {

    authKey = 'auth';
    editKey = 'edit';
    clientId = 'hcweb';

    constructor(private http: HttpClient, @Inject(PLATFORM_ID) private platformId: any) { }

    login(username: string, password: string): Observable<any> {
        const url = 'api/token/auth';
        const data = {
            username: username,
            password: password,
            clientId: this.clientId,
            grantType: 'password',
            scope: 'offline_access profile email'
        };
        return this.http.post<TokenResponse>(url, data);
    }

    logout(): boolean {
        this.setAuth(null);
        return true;
    }

    isLoggedIn(): boolean {
        if (isPlatformBrowser(this.platformId)) {
            return localStorage.getItem(this.authKey) != null;
        }
        return false;
    }

    getAuth(): TokenResponse | null {
        if (isPlatformBrowser(this.platformId)) {
            const i = localStorage.getItem(this.authKey);
            if (i) {
                return JSON.parse(i);
            }
        }
    }

    setAuth(auth: TokenResponse | null): boolean {
        if (isPlatformBrowser(this.platformId)) {
            if (auth) {
                localStorage.setItem(this.authKey, JSON.stringify(auth));
            } else {
                localStorage.removeItem(this.authKey);
            }
        }
        return true;
    }

    setEdit(editOn: boolean) {
        if (editOn) {
            localStorage.setItem(this.editKey, JSON.stringify(editOn));
        } else {
            localStorage.removeItem(this.editKey);
        }

    }

    isEdit(): boolean {
        return localStorage.getItem(this.editKey) != null;
    }

}
