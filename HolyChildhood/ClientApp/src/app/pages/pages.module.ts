import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PdfJsViewerModule } from 'ng2-pdfjs-viewer';

import { PagesRoutingModule } from './pages-routing.module';
import { PageComponent } from './page/page.component';
import { PagesService } from './pages.service';
import { EventService } from '../shared/services/event.service';
import { MessageService } from 'primeng/api';
import { ContentTextComponent } from './content-text/content-text.component';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';
import { FileUploadModule } from 'primeng/fileupload';
import { DropdownModule } from 'primeng/dropdown';
import { ToastModule } from 'primeng/toast';
import { ContentCalendarComponent } from './content-calendar/content-calendar.component';
import { ContentTabsComponent } from './content-tabs/content-tabs.component';
import { ContentFilesComponent } from './content-files/content-files.component';

import 'jquery';

@NgModule({
    imports: [
        CommonModule,
        PagesRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        FroalaEditorModule,
        FroalaViewModule,
        PdfJsViewerModule,
        DialogModule,
        ConfirmDialogModule,
        InputTextModule,
        FileUploadModule,
        DropdownModule,
        ToastModule,
        NgbModule,
    ],
    providers: [
        PagesService,
        ConfirmationService,
        EventService,
        MessageService
    ],
    declarations: [
        PageComponent,
        ContentTextComponent,
        ContentCalendarComponent,
        ContentTabsComponent,
        ContentFilesComponent
    ]
})
export class PagesModule { }
