import { Component, Input, EventEmitter, Output } from '@angular/core';
import { IFormField } from './form-field';

@Component({
    selector: 'pm-multi-line',
    templateUrl: './multi-line.component.html'
})
export class MultiLineComponent {
    @Input() value: IFormField;

    @Output() fieldClicked: EventEmitter<IFormField> = new EventEmitter<IFormField>();

    onClick(): void {
        this.fieldClicked.emit(this.value);
    }
}
