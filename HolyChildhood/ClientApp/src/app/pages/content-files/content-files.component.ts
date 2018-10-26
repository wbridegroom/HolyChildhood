import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { MessageService } from 'primeng/api';

import { PageContent } from './../../shared/models/page';
import { PagesService } from './../pages.service';
import { AuthService } from '../../shared/services/auth.service';
import { SelectItem } from 'primeng/api';
import { File } from '../../shared/models/file';

@Component({
  selector: 'content-files',
  templateUrl: './content-files.component.html',
  styleUrls: ['./content-files.component.css']
})
export class ContentFilesComponent implements OnInit {

    @Input() pageContent: PageContent;

    @ViewChild('embeddedPdfViewer') public embeddedPdfViewer;

    bulletins: File[];
    selectedBulletin: File;
    title: string;

    constructor(private http: HttpClient,
                private authService: AuthService,
                private pagesService: PagesService,
                private messageService: MessageService) { }

    ngOnInit() {
        this.loadBulletins();
    }

    loadBulletins() {
        this.bulletins = [];
        this.http.get<File[]>('/api/file').subscribe(bulletins => {
            this.bulletins = bulletins;
            this.bulletins[0].title = 'Current Week';
            this.selectedBulletin = this.bulletins[0];
            this.loadBulletin();
        });
    }

    loadBulletin() {
        let url = `/api/file/${this.selectedBulletin.id}`;
        this.embeddedPdfViewer.pdfSrc = url;
        this.embeddedPdfViewer.refresh();
    }

    upload(event) {
        const formData = new FormData();
        for (let file of event.files) {
            formData.append('files', file);
            formData.append('name', this.title);
        }
        this.http.post('/api/file', formData).subscribe(() => {
            this.title = "";
            this.messageService.add({severity: 'success', summary: 'Bulletin Uploaded Successfully', detail: ''});
            this.loadBulletins();
        });
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
