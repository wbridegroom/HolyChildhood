import { Component } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './../shared/services/auth.service';
import { InputTextModule } from 'primeng/inputtext';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    title: string;
    form: FormGroup;

    constructor(private router: Router, private fb: FormBuilder, private authService: AuthService) {
        this.title = 'User Login';
        this.createForm();
    }

    createForm() {
        this.form = this.fb.group({
            Username: ['', Validators.required],
            Password: ['', Validators.required]
        });
    }

    onSubmit() {
        const username = this.form.value.Username;
        const password = this.form.value.Password;

        this.authService.login(username, password).subscribe(res => {
            this.router.navigate(['home']);
        }, err => {
            console.log(err);
            this.form.setErrors({
                'auth': 'Incorrect username or password'
            });
        });
    }

    onBack() {
        this.router.navigate(['home']);
    }

    getFormControl(name: string) {
        return this.form.get(name);
    }

    isValid(name: string) {
        const e = this.getFormControl(name);
        return e && e.valid;
    }

    isChanged(name: string) {
        const e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    }

    hasError(name: string) {
        const e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    }

}
