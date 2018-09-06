import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRouting } from './app.routing';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { PageService } from './shared/services/page.service';
import { EventService } from './shared/services/event.service';
import { SettingsComponent } from './settings/settings.component';
import { SettingsService } from './shared/services/settings.service';
import { environment } from './../environments/environment';
import { PageComponent } from './page/page.component';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';
import { LoginComponent } from './login/login.component';
import { AuthService } from './shared/services/auth.service';
import { AuthInterceptor } from './shared/services/auth.interceptor';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';

export function settingsFactory(service: SettingsService) {
    return () => service.load();
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SettingsComponent,
    PageComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    DialogModule,
    ButtonModule,
    TableModule,
    ConfirmDialogModule,
    InputTextModule,
    InputTextareaModule,
    HttpClientModule,
    FroalaEditorModule,
    FroalaViewModule,
    AppRouting
  ],
  providers: [
    SettingsService,
    {
        provide: APP_INITIALIZER, useFactory: settingsFactory, deps: [SettingsService], multi: true
    },
    PageService,
    EventService,
    AuthService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true
    },
    ConfirmationService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
