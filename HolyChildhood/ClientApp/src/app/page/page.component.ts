import 'rxjs/add/operator/switchMap';

import { ActivatedRoute, ParamMap } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import { PageContent } from './../shared/models/page-content';
import { PageService } from './../shared/services/page.service';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ConfirmationService} from 'primeng/api';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent implements OnInit {

    contentList$: Observable<PageContent[]>;
    pageId: string;

    constructor(private pageService: PageService, 
                private route: ActivatedRoute, 
                private router: Router, 
                private confirmService: ConfirmationService) { }

    ngOnInit() {
        this.contentList$ = this.route.paramMap.switchMap((params: ParamMap) => {
            this.pageId = params.get('id');
            return this.pageService.getPageContent(params.get('id'));  
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
}
