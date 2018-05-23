import { Component, OnDestroy, OnInit } from '@angular/core';

import { Page } from './../shared/models/page';
import { PageService } from './../shared/services/page.service';
import { AuthService } from './../shared/services/auth.service';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    isExpanded = false;
    displayAddPageDialog = false;
    newPage: Page = {} as Page;

    constructor(private authService: AuthService, public pageService: PageService) {}

    ngOnInit() {
        this.getPages();
    }

    ngOnDestroy() {
    }

    logout() {
        this.authService.logout();
    }

    isAuthenticated(): boolean {
        return this.authService.isLoggedIn();
    }

    getUserName(): string {
        const auth = this.authService.getAuth();
        const userName = auth.userName;
        return userName;
    }

    getPages() {
        this.pageService.getTopLevelPages();
    }

    showAddPageDialog() {
        this.newPage = {} as Page;
        this.displayAddPageDialog = true;
    }

    addPage(): void {
        console.log(`Adding Page: ${this.newPage.title}`);
        this.displayAddPageDialog = false;
        this.pageService.addPage(this.newPage);
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
}
