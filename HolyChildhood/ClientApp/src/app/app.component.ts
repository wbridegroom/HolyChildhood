import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Setting } from './shared/models/setting';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  settings: Setting[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getSettings();
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
