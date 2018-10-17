import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRouting } from './app.routing';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { EventService } from './shared/services/event.service';
import { SettingsComponent } from './settings/settings.component';
import { SettingsService } from './shared/services/settings.service';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { TableModule } from 'primeng/table';
import { ListboxModule } from 'primeng/listbox';
import { InputTextModule } from 'primeng/inputtext';
import { LoginComponent } from './login/login.component';
import { AuthService } from './shared/services/auth.service';
import { AuthInterceptor } from './shared/services/auth.interceptor';

import { PagesModule } from './pages/pages.module';

export function settingsFactory(service: SettingsService) {
    return () => service.load();
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SettingsComponent,
    LoginComponent
  ],
  imports: [
    PagesModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    DialogModule,
    ButtonModule,
    DropdownModule,
    TableModule,
    ListboxModule,
    InputTextModule,
    InputTextareaModule,
    HttpClientModule,
    AppRouting
  ],
  providers: [
    SettingsService,
    {
        provide: APP_INITIALIZER, useFactory: settingsFactory, deps: [SettingsService], multi: true
    },
    EventService,
    AuthService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true
    }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
