import { ActivatedRoute, ParamMap } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { PageService } from './../shared/services/page.service';
import { ConfirmationService } from 'primeng/api';
import { AuthService } from '../shared/services/auth.service';
import { Page } from './../shared/models/page';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent implements OnInit {
    pageId: string;
    isEdit = false;
    displayEditPageDialog = false;
    pageEdit: Page;
    options: Object = {
        imageUploadURL: '/api/image',
        imageManagerDeleteMethod: 'DELETE',
        imageManagerDeleteURL: '/api/image',
        imageManagerLoadURL: '/api/image'
    };

    events: any[];

    constructor(private authService: AuthService,
                public pageService: PageService,
                private route: ActivatedRoute,
                private router: Router,
                private confirmService: ConfirmationService) { }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.pageId = params.get('id');
            this.pageService.loadPage(this.pageId);
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

    addCalender() {
        this.pageService.addCalender(this.pageId);
    }

    editPage() {
        this.pageEdit = Object.assign({}, this.pageService.page);
        this.displayEditPageDialog = true;
    }

    updatePage() {
        this.pageService.updatePage(this.pageEdit);
        this.displayEditPageDialog = false;
    }

    editContent(pageContent) {
        pageContent.editing = true;
    }

    saveContent(pageContent) {
        pageContent.editing = false;
        this.pageService.updatePageContent(pageContent);
    }

    cancelEdit(pageContent) {
        pageContent.editing = false;
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

    isEditOn(): boolean {
        return this.isAuthenticated() && this.authService.isEdit();
    }
}
