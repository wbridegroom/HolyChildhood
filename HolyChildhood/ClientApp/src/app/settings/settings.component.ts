import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { UserService } from './../shared/services/user.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

    name: string;
    email: string;

    constructor(private http: HttpClient, private userService: UserService) { }

    ngOnInit() {
        this.getUserDetails();
    }

    getUserDetails() {
        this.http.get('/api/settings').subscribe(data => {
            console.log(`Data: ${data}`);
            this.name = data['name'];
            this.email = data['email'];
        });
    }

}
