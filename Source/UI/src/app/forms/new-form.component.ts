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

    public form: IForm;
    errorMessage: string;

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
        this.form.id = this.form.title.replace(/ /g, '');

        this._formsService.addNewForm(this.form).subscribe(
            forms => {
                this._router.navigate(['/builder', this.form.id]);
          },
            error => {this.errorMessage = <any>error;
              alert(this.errorMessage);
            });

    }
    onCancelClick(): void {
        this._router.navigate(['/myforms']);
    }
}
