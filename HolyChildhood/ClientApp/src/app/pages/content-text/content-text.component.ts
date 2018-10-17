import { Component, Input } from '@angular/core';

import { PageContent } from './../../shared/models/page';
import { PagesService } from './../pages.service';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'content-text',
  templateUrl: './content-text.component.html',
  styleUrls: ['./content-text.component.css']
})
export class ContentTextComponent {

    @Input() pageContent: PageContent;

    options: Object = {
        imageUploadURL: '/api/image',
        imageManagerDeleteMethod: 'DELETE',
        imageManagerDeleteURL: '/api/image',
        imageManagerLoadURL: '/api/image'
    };

    constructor(private authService: AuthService, private pagesService: PagesService) { }

    isAuthenticated(): boolean {
        return this.authService.isLoggedIn();
    }

    isEditOn(): boolean {
        return this.isAuthenticated() && this.authService.isEdit();
    }

    editContent() {
        this.pageContent.editing = true;
    }

    saveContent() {
        this.pageContent.editing = false;
        this.pagesService.updatePageContent(this.pageContent);
    }

    cancelEdit() {
        this.pageContent.editing = false;
    }

    deleteContent() {
        let id = this.pageContent.id;
        console.log(`Delete Page Content Id: ${id}`);
        this.pagesService.deletePageContent(id).subscribe(() => {
            this.pagesService.reloadPage();
        });
    }

}
