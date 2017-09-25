import { Component, OnInit } from '@angular/core';
import { IFormField, IForm } from './field_template/form-field';
import { FormsService } from './forms.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'pm-new-form',
    templateUrl: './new-form.component.html',
})
export class NewFormComponent implements OnInit {

    constructor(private _route: ActivatedRoute,
        private _router: Router,
        private _formsService: FormsService) {
    }

    public formUserName: string;
    public form: IForm;

    ngOnInit() {
        // TODO - Get all the saved forms under this user.
        this.form = {
            id: '',
            title: '',
            description: '',
            fields: null
        };
    }

    onCreateClick(): void {
        // TODO - Create a new form in the server
        this.form.id = this._formsService.addNewForm(this.form);
        this._router.navigate(['/builder', this.form.id]);
    }
    onCancelClick(): void {
        this._router.navigate(['/myforms']);
    }
}
