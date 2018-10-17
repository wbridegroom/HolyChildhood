import { Component, OnInit } from '@angular/core';

import { Page } from './../shared/models/page';
import { NavService } from './../shared/services/nav.service';
import { AuthService } from './../shared/services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
    isExpanded = false;
    displayAddPageDialog = false;
    newPage: Page = {} as Page;

    constructor(private authService: AuthService, public navService: NavService) {}

    ngOnInit() {
        this.getPages();
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
        this.navService.getTopLevelPages();
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
        this.navService.addPage(this.newPage);
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
