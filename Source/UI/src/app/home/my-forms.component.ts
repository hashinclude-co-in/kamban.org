import { Component, OnInit } from '@angular/core';
import { IForm, IFormField } from '../forms/field_template/form-field';
import { FormsService } from '../forms/forms.service';

@Component({
    templateUrl: './my-forms.component.html'
})
export class MyFormsComponent implements OnInit {
    public pageTitle: string = 'My Forms';
    forms: IFormField[];
    errorMessage: string;

    constructor(private _formService: FormsService) {
    }
    ngOnInit() {
        this._formService.getAllForms().subscribe(
            forms => {this.forms = forms;
          },
            error => {this.errorMessage = <any>error;
              alert(this.errorMessage);
            });
    }
}
