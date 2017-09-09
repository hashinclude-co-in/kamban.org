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
    title: string = 'test title from component';
    description: string = 'test description from component';
    fieldList: IFormField[] = [
        {
            'index': 0,
            'type': 'single-line-field',
            'title': 'test title 1 from component modified',
            'value': 'test value1',
            'instruction': 'Sample instruction 1',
            'mandatory': false
        },
        {
            'index': 1,
            'type': 'multi-line-field',
            'title': 'test title 2  from component',
            'value': 'test value2',
            'instruction': 'Sample instruction 2',
            'mandatory': false
        },
    ];
    selectedField: IFormField = this.fieldList[0];

    onFieldClicked(message: IFormField): void {
        this.selectedField = message;
        this.fieldList[message.index] = message;
    }
}
