import { Component, OnDestroy, OnInit } from '@angular/core';

import { Page } from './../shared/models/page';
import { PageService } from './../shared/services/page.service';
import { UserService } from './../shared/services/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    isExpanded = false;

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

    test() {
        console.info("This is a test");
    }

    addPage(): void {
        console.info("Adding Page");
        const title = "Test 1";
        this.pageService.addPage({ title } as Page);
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
}
