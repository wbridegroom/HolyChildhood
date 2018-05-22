import 'rxjs/add/observable/fromPromise';
import 'rxjs/add/operator/switchMap';

import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UserService } from './../services/user.service';

@Injectable()
export class AuthenticationHttpInterceptor implements HttpInterceptor {
    constructor(private userService: UserService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return Observable.fromPromise(this.userService.getToken())
            .switchMap(token => {
                console.log(`Interceptor: Setting token=${token}`);
                req = req.clone({
                    setHeaders: {
                        Authorization: `Bearer ${token}`
                    }
                });
                return next.handle(req);
            });
    }
}
