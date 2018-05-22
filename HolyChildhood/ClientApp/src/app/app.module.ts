import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRouting } from './app.routing';
import { AuthenticationHttpInterceptor } from './shared/interceptors/authentication.httpInterceptor';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { HttpModule } from '@angular/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule } from '@angular/core';
import { PageService } from './shared/services/page.service';
import { SettingsComponent } from './settings/settings.component';
import { UserService } from './shared/services/user.service';
import { environment } from './../environments/environment';
import { PageComponent } from './page/page.component';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SettingsComponent,
    PageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    DialogModule,
    ButtonModule,
    ConfirmDialogModule,
    InputTextModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    AppRouting
  ],
  providers: [
    PageService,
    UserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationHttpInterceptor,
      multi: true
    },
    ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
