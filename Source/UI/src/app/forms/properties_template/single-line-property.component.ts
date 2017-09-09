import { Component, Input, EventEmitter, Output } from '@angular/core';
import { IFormField } from '../field_template/form-field';

@Component({
    selector: 'pm-single-line-property',
    templateUrl: './single-line-property.component.html'
})
export class SingleLinePropertyComponent {
    @Input() value: IFormField;

    @Output() ratingClicked: EventEmitter<string> = new EventEmitter<string>();

    onTitleChange(changedTitle: string): void {

        this.value.title = changedTitle;
    }
}
