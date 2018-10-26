import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { Page } from './../models/page';

@Injectable({
  providedIn: 'root'
})
export class NavService {

    public pages: Page[];

    constructor(private httpClient: HttpClient, private router: Router) { }

    public getTopLevelPages() {
        this.httpClient.get('/api/page').subscribe((pages: Page[]) => this.pages = pages);
    }

    public addPage(page: Page) {
        const options = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
        };
        this.httpClient.post<Page>('/api/page', page, options).subscribe(res => {
            this.getTopLevelPages();
            this.router.navigate([`/pages/${res.id}`]);
        });
    }

}
