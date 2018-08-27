import { Component, OnInit } from '@angular/core';
import { EventService } from './../shared/services/event.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    constructor(public eventService: EventService) { }

    ngOnInit() {
        this.eventService.loadEvents();
    }
}
