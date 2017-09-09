import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IFormField } from './form-field';

@Component({
    selector: 'pm-single-line',
    templateUrl: './single-line.component.html'
})
export class SingleLineComponent {
    @Input() value: IFormField;

    @Output() fieldClicked: EventEmitter<IFormField> = new EventEmitter<IFormField>();

    onClick(): void {
        this.fieldClicked.emit(
            {
                'index': this.value.index,
                'type': this.value.type,
                'title': this.value.title,
                'value': this.value.value,
                'instruction': this.value.instruction
            }
        );
    }
}
