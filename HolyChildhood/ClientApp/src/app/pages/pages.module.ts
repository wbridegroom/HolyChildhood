import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { FullCalendarModule } from 'ng-fullcalendar';

import { PagesRoutingModule } from './pages-routing.module';
import { PageComponent } from './page/page.component';
import { PagesService } from './pages.service';
import { EventService } from '../shared/services/event.service';
import { ContentTextComponent } from './content-text/content-text.component';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { ContentCalendarComponent } from './content-calendar/content-calendar.component';
import { ContentTabsComponent } from './content-tabs/content-tabs.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import 'jquery';

@NgModule({
  imports: [
    CommonModule,
    PagesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    FroalaEditorModule,
    FroalaViewModule,
    FullCalendarModule,
    DialogModule,
    ConfirmDialogModule,
    InputTextModule,
    NgbModule,
  ],
  providers: [
      PagesService,
      ConfirmationService,
      EventService
  ],
  declarations: [PageComponent, ContentTextComponent, ContentCalendarComponent, ContentTabsComponent]
})
export class PagesModule { }
