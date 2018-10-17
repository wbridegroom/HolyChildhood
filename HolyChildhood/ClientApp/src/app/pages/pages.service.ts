import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { Page, PageContent } from '../shared/models/page';
import { NavService } from '../shared/services/nav.service';

const http_options = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
};

@Injectable({
  providedIn: 'root'
})
export class PagesService {

    public page: Page;

    constructor(private http: HttpClient, private router: Router, private nav: NavService) { }

    public loadPage(id) {
        this.getPage(id).subscribe(page => this.page = page);
    }

    public reloadPage() {
        this.loadPage(this.page.id)
    }

    public getPage(id: number | string) : Observable<Page> {
        const url = `/api/page/${id}`;
        return this.http.get<Page>(url);
    }

    public updatePage(page: Page) {
        const url = `/api/page`;
        this.http.put(url, page, http_options).subscribe(() => {
            this.nav.getTopLevelPages();
            this.loadPage(page.id);
        });
    }

    public deletePage() {
        const url = `/api/page/${this.page.id}`;
        this.http.delete<Page>(url).subscribe(() => {
            this.nav.getTopLevelPages();
            this.router.navigate(['/home']);
        });
    }

    public addPageContent(contentType) {
        const url = `/api/pagecontent/create/${this.page.id}`;
        const newContent = { content: '<p>New Content</p>', contentType: contentType} as PageContent;
        this.http.post(url, newContent, http_options).subscribe(() => {
            this.reloadPage();
        });
    }

    public updatePageContent(pageContent: PageContent) {
        const url = `/api/pagecontent/update`;
        this.http.put(url, pageContent, http_options).subscribe();
    }

    public deletePageContent(id: number | string) {
        const url = `/api/pagecontent/delete/${id}`;
        return this.http.delete(url);
    }
}
