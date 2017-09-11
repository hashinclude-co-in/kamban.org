import { Component} from '@angular/core';
import { IFormField } from './field_template/form-field';
import { FormsService } from './forms.service';

@Component({
    selector: 'pm-new-form',
    templateUrl: './new-form.component.html',
})
export class NewFormComponent {
    constructor(private _formsService: FormsService) {
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

    onFieldClicked(message: IFormField): void {
        this.selectedField = message;
        this.fieldList[message.index] = message;
    }
    newFieldAdded(message: IFormField[]): void {
        this.fieldList = message;
        this.selectedField = this.fieldList[this.fieldList.length - 1];
    }
    onClick(): void {
        this.selectedField = this.fieldList[0];
    }
}
