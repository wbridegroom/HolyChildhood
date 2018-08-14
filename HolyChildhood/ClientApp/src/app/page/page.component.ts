import 'rxjs/add/operator/switchMap';

import { ActivatedRoute, ParamMap } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import { PageContent } from './../shared/models/page-content';
import { PageService } from './../shared/services/page.service';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent implements OnInit {

    pageId: string;
    isEdit = false;

    constructor(private authService: AuthService,
                public pageService: PageService,
                private route: ActivatedRoute,
                private router: Router,
                private confirmService: ConfirmationService) { }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.pageId = params.get('id');
            console.log(`Page Id: ${this.pageId}`);
            this.pageService.loadPageContent(this.pageId);
        });
    }

    deletePage() {
        this.confirmService.confirm({
            message: 'Are you sure you want to delete this page?',
            accept: () => {
                this.pageService.deletePage(this.pageId);
            }
        });
    }

    addContent() {
        this.pageService.addPageContent(this.pageId);
    }

    editContent(pageContent) {
        pageContent.editing = true;
    }

    saveContent(pageContent) {
        pageContent.editing = false;
        this.pageService.updatePageContent(pageContent);
    }

    deleteContent(id: string) {
        console.log(`Delete Page Content Id: ${id}`);
        this.pageService.deletePageContent(id).subscribe(data => {
            this.pageService.loadPageContent(this.pageId);
        });
    }

    isAuthenticated(): boolean {
        return this.authService.isLoggedIn();
    }
}
