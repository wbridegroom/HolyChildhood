import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Setting } from './../models/setting';
import { Parishioner } from './../models/user';

@Injectable()
export class SettingsService {

    settings: Setting[];
    parishioners: Parishioner[];

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
        let url = '/api/settings';
        this.http.get<Setting[]>(url).subscribe(settings => this.settings = settings);

        url = '/api/parishioners';
        this.http.get<Parishioner[]>(url).subscribe(parishioners => this.parishioners = parishioners);
    }

    getParishioners(): Observable<Parishioner[]> {
        const url = '/api/parishioners';
        return this.http.get<Parishioner[]>(url);
    }
}

