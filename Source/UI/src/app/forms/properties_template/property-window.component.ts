import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IFormField } from '../field_template/form-field';

@Component({
    selector: 'pm-property-window',
    templateUrl: './property-window.component.html'
})
export class PropertyWindowComponent {
    @Input() typeValue: IFormField;

    @Output() valueChanged: EventEmitter<string> = new EventEmitter<string>();

    onRatingClicked(changedValue: string) {
        alert(changedValue);
        this.valueChanged.emit(changedValue);
    }
}
