import { Component, OnInit, Input } from '@angular/core';

import { PageContent } from './../../shared/models/page';
import { PagesService } from './../pages.service';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'content-tabs',
  templateUrl: './content-tabs.component.html',
  styleUrls: ['./content-tabs.component.css']
})
export class ContentTabsComponent implements OnInit {

    @Input() pageContent: PageContent;

    constructor(private authService: AuthService, private pagesService: PagesService) { }

    ngOnInit() {
    }

    isAuthenticated(): boolean {
        return this.authService.isLoggedIn();
    }

    isEditOn(): boolean {
        return this.isAuthenticated() && this.authService.isEdit();
    }

    deleteContent() {
        let id = this.pageContent.id;
        console.log(`Delete Page Content Id: ${id}`);
        this.pagesService.deletePageContent(id).subscribe(() => {
            this.pagesService.reloadPage();
        });
    }

}
