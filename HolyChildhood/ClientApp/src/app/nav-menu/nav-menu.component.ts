import { Component, OnDestroy, OnInit } from '@angular/core';

import { Page } from './../shared/models/page';
import { PageService } from './../shared/services/page.service';
import { UserService } from './../shared/services/user.service';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    isExpanded = false;
    displayAddPageDialog: boolean = false;
    newPage: Page = {} as Page;

    constructor(private userService: UserService, public pageService: PageService) {}

    ngOnInit() {
        this.getPages();
    }

    ngOnDestroy() {
    }

    login() {
        this.userService.login();
    }

    logout() {
        this.userService.logout();
    }

    isAuthenticated(): boolean {
        return this.userService.isLoggedIn();
    }

    getUserName(): string {
        return this.userService.getUser().name;
    }

    getPages() {
        this.pageService.getTopLevelPages();
    }

    showAddPageDialog() {
        this.newPage = {} as Page;
        this.displayAddPageDialog = true;
    }

    addPage(): void {
        console.info(`Adding Page: ${this.newPage.title}`);
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
