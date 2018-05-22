import * as Msal from 'msal';

import { Injectable } from '@angular/core';
import { User } from 'msal/lib-commonjs/User';
import { environment } from './../../../environments/environment';

@Injectable()
export class UserService {

    private authority = `https://login.microsoftonline.com/tfp/${environment.tenant}/${environment.signUpSignInPolicy}`;
    private clientApplication: Msal.UserAgentApplication;
    private logger: Msal.Logger;
    private token: string;

    constructor() {
        this.clientApplication = new Msal.UserAgentApplication(environment.clientID, this.authority, this.authCallback, {
            cacheLocation: 'localStorage'
        });
    }

    login() {
        // localStorage.addItem('auth_token', 'token str');
        this.clientApplication.loginRedirect(environment.b2cScopes);
    }

    logout() {
        // localStorage.removeItem('auth_token');
        this.clientApplication.logout();
    }

    public getUser(): User {
        const user = this.clientApplication.getUser();
        console.log(`Calling getUser(): ${user}`);
        return user;
    }

    isLoggedIn(): boolean {
        const loggedIn = this.clientApplication.getUser() != null;
        console.log(`Calling isLoggedIn(): ${loggedIn}`);
        return loggedIn;
    }

    public getToken(): Promise<string> {
        return this.clientApplication.acquireTokenSilent(environment.b2cScopes).then(token => {
            return token;
        }).catch(error => {
            return this.clientApplication.acquireTokenPopup(environment.b2cScopes).then(token => {
                return Promise.resolve(token);
            }).catch(innererror => {
                console.error('Could not retrieve token from popup.', innererror);
                return Promise.resolve('');
            });
        });
    }

    private authCallback(errorDesc: any, token: any, error: any, tokenType: any) {
        if (error) {
            console.error(`${error} ${errorDesc}`);
        } else if (token) {
            this.token = token;
            console.log(`Token: ${token}`);
            console.log(`User: ${this.getUser().name}`);
        }
    }
}
