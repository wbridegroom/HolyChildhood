import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Setting } from './../models/setting';

@Injectable()
export class SettingsService {

    settings: Setting[];

    constructor(private http: HttpClient) { }

    get(key) {
        let setting = this.settings.filter(s => s.key === key)[0];
        return setting.value;
    }

    getAll() {
        return this.settings;
    }

    getSetting(key) {
        return this.settings.filter(s => s.key === key)[0];
    }

    save(updated_setting) {
        const url = `/api/settings`;
        const options = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
        };
        this.http.put(url, updated_setting, options).subscribe(() => {
            let setting = this.settings.filter(s => s.key === updated_setting.key)[0];
            setting.value = updated_setting.value;
        });
    }

    load() {
        console.log('Loading settings');
        const url = '/api/settings';
        this.http.get(url).subscribe((data: Setting[]) => {
            this.settings = data;
        })
    }
}
4
