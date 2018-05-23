import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

    name: string;
    email: string;

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.getUserDetails();
    }

    getUserDetails() {
        this.http.get('/api/settings').subscribe(data => {
            console.log(`Data: ${JSON.stringify(data)}`);
            this.name = data['firstName'] + ' ' + data['lastName'];
            this.email = data['email'];
        });
    }

}
