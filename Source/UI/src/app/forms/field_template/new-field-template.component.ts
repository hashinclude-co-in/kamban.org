import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IFormField } from './form-field';

@Component({
    selector: 'pm-new-field-template',
    templateUrl: './new-field-template.component.html'
})
export class NewFieldTemplateComponent {

    @Input() allFields: IFormField[];
    @Output() fieldAdded: EventEmitter<IFormField[]> = new EventEmitter<IFormField[]>();

    createSingleLine(): void {
        this.allFields.push({
            'index': this.allFields.length,
            'type': 'pm-single-line',
            'title': 'Single Line',
            'value': 'Default Text',
            'instruction': 'Default Instruction',
            'mandatory': false
        });
        this.fieldAdded.emit(this.allFields);
    }
    createMultiLine(): void {
        this.allFields.push({
            'index': this.allFields.length,
            'type': 'pm-multi-line',
            'title': 'Multi Line',
            'value': 'Default Text',
            'instruction': 'Default Instruction',
            'mandatory': false
        });
        this.fieldAdded.emit(this.allFields);
    }
}
