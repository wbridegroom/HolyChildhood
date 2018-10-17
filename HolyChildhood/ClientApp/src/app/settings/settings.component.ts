import { Component, OnInit } from '@angular/core';

import { Setting } from './../shared/models/setting';
import { SettingsService } from '../shared/services/settings.service';
import { Parishioner } from './../shared/models/user';
import { SelectItem } from 'primeng/api';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent  implements OnInit {

    titles: SelectItem[] = [
        {label:'Fr', value:'Father'},
        {label:'Mr', value:'Mr'},
        {label:'Mrs', value:'Mrs'},
        {label:'Ms', value:'Ms'},
        {label:'Miss', value:'Miss'},
        {label:'Dr', value:'Dr'},
        {label:'Deacon', value:'Deacon'},
    ]

    name: string;
    email: string;
    setting: Setting;
    displaySettingDialog: boolean = false;
    parishioners: Parishioner[];
    selectedParishioner: Parishioner;
    editParishioner: boolean = false;

    constructor(public settings: SettingsService) { }

    ngOnInit() {
        this.getParishioners();
    }

    getParishioners(): void {
        this.settings.getParishioners().subscribe(parishioners => {
            this.parishioners = parishioners
            for (var i = 0, len = this.parishioners.length; i < len; i++) {
                this.parishioners[i].fullName = this.parishioners[i].title + ' ' + this.parishioners[i].firstName + ' ' + this.parishioners[i].lastName;
            }
        });
    }

    saveParishioner() {
        this.editParishioner = false;
    }

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
