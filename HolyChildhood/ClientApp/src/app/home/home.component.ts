import { Component, OnInit } from '@angular/core';
import { EventService } from './../shared/services/event.service';
import { HttpClient } from '@angular/common/http';
import { Setting } from '../shared/models/setting';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    settings: Setting[];

    constructor(private http: HttpClient, public eventService: EventService) { }

    ngOnInit() {
        this.getSettings();
        this.eventService.loadEvents();
    }

    getSettings() {
        this.http.get('/api/settings').subscribe((data: Setting[]) => {
            this.settings = data;
        });
    }

    getSetting(key) {
        if (key && this.settings) {
            let setting = this.settings.filter(s => s.key === key)[0];
            return setting.value;
        } else {
            return '';
        }
    }
}
