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


    fieldList: IFormField[] = [{
        'index': 0,
        'type': 'form-field',
        'title': 'Form title given by user.',
        'value': 'Form description given by user.',
        'instruction': '',
        'mandatory': false
    }];
    selectedField: IFormField = this.fieldList[0];
    form: IForm;

    ngOnInit() {
        const formId: string = this._route.snapshot.paramMap.get('formId').toString();
        this.form = this._formsService.getForm(formId);
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
