import { Component} from '@angular/core';

import { Setting } from './../shared/models/setting';
import { SettingsService } from '../shared/services/settings.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent {

    name: string;
    email: string;
    setting: Setting;
    displaySettingDialog: boolean = false;

    constructor(public settings: SettingsService) { }

    editSetting(setting) {
        this.setting = Object.assign({}, setting);
        this.displaySettingDialog  = true;
    }

    saveSetting() {
        this.settings.save(this.setting);
        this.displaySettingDialog  = false;
    }

    cancelEdit() {
        this.displaySettingDialog  = false;
    }

}
