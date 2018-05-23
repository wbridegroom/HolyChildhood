import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class AuthService {

    authKey = 'auth';
    clientId = 'hcweb';

    constructor(private http: HttpClient, @Inject(PLATFORM_ID) private platformId: any) { }

    login(username: string, password: string): Observable<boolean> {
        const url = 'api/token/auth';
        const data = {
            username: username,
            password: password,
            clientId: this.clientId,
            grantType: 'password',
            scope: 'offline_access profile email'
        };
        return this.http.post<TokenResponse>(url, data).map((res) => {
            const token = res && res.token;
            if (token) {
                this.setAuth(res);
                return true;
            }
            return Observable.throw('Unauthorized');
        }).catch(error => {
            return new Observable<any>(error);
        });
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

}
