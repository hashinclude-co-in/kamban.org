import { Component, OnInit } from '@angular/core';
import { IFormField, IForm } from './field_template/form-field';
import { FormsService } from './forms.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'pm-form-builder',
    templateUrl: './form-builder.component.html',
})
export class FormBuilderComponent implements OnInit {
    constructor(private _route: ActivatedRoute,
        private _router: Router,
        private _formsService: FormsService) {
    }


    fieldList: IFormField[] = [];
    selectedField: IFormField;
    form: IForm;

    ngOnInit() {
        const formId: string = this._route.snapshot.paramMap.get('formId').toString();
        this.form = this._formsService.getForm(formId);
        if (this.form === undefined) {
            this._router.navigate(['/newform']);
        }
    }

    onFieldClicked(message: IFormField): void {
        this.selectedField = message;
        this.fieldList[message.index] = message;
    }
    newFieldAdded(message: IFormField[]): void {
        this.fieldList = message;
        this.selectedField = this.fieldList[this.fieldList.length - 1];
    }
    onClick(): void {
        this.selectedField = null;
    }
}
