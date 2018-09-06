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

    hasSubPages(page) {
        if (page.children.length > 0) {
            return true;
        }
    }

    showAddPageDialog(page) {
        this.newPage = {} as Page;
        if (page) {
            this.newPage.parent = page;
        }
        this.displayAddPageDialog = true;
    }

    addPage(): void {
        this.displayAddPageDialog = false;
        this.pageService.addPage(this.newPage);
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    isEdit() {
        return this.isAuthenticated() && this.authService.isEdit();
    }

    getEditMenuItem() {
        if (this.authService.isEdit()) {
            return "Turn off Editing";
        } else {
            return "Turn on Editing";
        }
    }

    toggleEditMode() {
        if (this.authService.isEdit()) {
            this.authService.setEdit(false);
        } else {
            this.authService.setEdit(true);
        }
    }
}
