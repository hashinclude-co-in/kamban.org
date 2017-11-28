import { Component, OnInit } from '@angular/core';
import { IForm, IFormField } from '../forms/field_template/form-field';
import { FormsService } from '../forms/forms.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './my-forms.component.html'
})
export class MyFormsComponent implements OnInit {
    public pageTitle: string = 'My Forms';
    forms: IForm[];
    errorMessage: string;

    constructor(private _formService: FormsService,
        private _router: Router) {
    }
    ngOnInit() {
        this._formService.getAllForms().subscribe(
            forms => {
                this.forms = forms;
            },
            error => {
                this.errorMessage = <any>error;
                alert(this.errorMessage);
            });
    }

    onFormClick(value: string): void {
        this._router.navigate(['/builder', value]);
    }
}
