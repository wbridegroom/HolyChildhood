import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Setting } from '../shared/models/setting';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

    name: string;
    email: string;
    settings: Setting[];
    displaySettingDialog: boolean = false;
    setting: Setting;

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.getSettings();
        this.getUserDetails();
    }

    getSettings() {
        this.http.get('/api/settings').subscribe((data: Setting[]) => {
            this.settings = data;
        });
    }

    editSetting(setting) {
        this.setting = setting;
        this.displaySettingDialog  = true;
    }

    saveSetting() {
        const url = `/api/settings`;
        const options = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
        };
        this.http.put(url, this.setting, options).subscribe();
        this.displaySettingDialog  = false;
    }

    cancelEdit() {
        this.displaySettingDialog  = false;
    }

    getUserDetails() {
        this.http.get('/api/settings').subscribe(data => {
            this.name = data['firstName'] + ' ' + data['lastName'];
            this.email = data['email'];
        });
    }

}
