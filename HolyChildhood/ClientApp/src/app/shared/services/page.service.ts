import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { Page } from './../models/page';
import { PageContent } from './../models/page-content';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable()
export class PageService {

    pages: Page[];
    pageContents: PageContent[];

    constructor(private httpClient: HttpClient, private router: Router) { }

    public getTopLevelPages() {
        this.httpClient.get('/api/page').subscribe((data: Page[]) => {
            this.pages = data;
        });
    }

    public loadPageContent(id: number | string) {
        this.httpClient.get<PageContent[]>(`/api/pagecontent/list/${id}`).subscribe((data: PageContent[]) => {
            this.pageContents = data;
        });
    }

    public addPage(page: Page) {
        const options = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
          };
        this.httpClient.post<Page>('/api/page', page, options).subscribe(res => {
            this.pages.push(res);
            this.router.navigate([`/page/${res.id}`]);
        });
    }

    public deletePage(id: string) {
        const url = `/api/page/${id}`;
        console.log(`URL: ${url}`);
        this.httpClient.delete<Page>(url).subscribe(data => {
            this.getTopLevelPages();
            this.router.navigate(['/home']);
        });
    }

    public addPageContent(pageId: string) {
        const url = `/api/pagecontent/create/${pageId}`;
        const options = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
        };
        const newContent = { content: '<p>New Content</p>'} as PageContent;
        this.httpClient.post(url, newContent, options).subscribe((data: PageContent) => {
            this.pageContents.push(data);
        });
    }

    public deletePageContent(id: string) {
        const url = `/api/pagecontent/delete/${id}`;
        const options = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
        };
        return this.httpClient.delete(url);
    }

    public updatePageContent(pageContent: PageContent) {

    }
}
