import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class EventService {

    events: Event[];

    constructor(private httpClient: HttpClient) { }

    public loadEvents() {
        this.httpClient.get<Event[]>('/api/event').subscribe((data: Event[]) => {
            this.events = data;
        });
    }
}
