import { Component, OnInit } from '@angular/core';
import { EventService } from './../shared/services/event.service';
import { SettingsService } from '../shared/services/settings.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    constructor(public eventService: EventService,
                public settings: SettingsService) { }

    ngOnInit() {
        this.eventService.loadEvents();
    }
}
