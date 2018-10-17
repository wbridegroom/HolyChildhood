import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ModuleWithProviders } from '@angular/core';
import { SettingsComponent } from './settings/settings.component';
import { LoginComponent } from './login/login.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent },
    { path: 'pages', loadChildren: './pages/pages.module#PagesModule'},
    { path: 'settings', component: SettingsComponent },
    { path: 'login', component: LoginComponent }
];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);
