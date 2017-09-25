import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IFormField, IForm } from '../field_template/form-field';

@Component({
    selector: 'pm-property-window',
    templateUrl: './property-window.component.html'
})
export class PropertyWindowComponent {
    @Input() typeValue: IFormField;
    @Input() formValue: IForm;

    @Output() valueChanged: EventEmitter<string> = new EventEmitter<string>();

    onRatingClicked(changedValue: string) {
        alert(changedValue);
        this.valueChanged.emit(changedValue);
    }
}
