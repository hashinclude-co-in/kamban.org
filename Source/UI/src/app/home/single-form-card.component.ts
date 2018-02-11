import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IForm } from '../forms/field_template/form-field';

@Component({
    selector: 'pm-single-form-card',
    templateUrl: './single-form-card.component.html'
})
export class SingleFormCardComponent {
    @Input() form: IForm;

    @Output() clickEmit: EventEmitter<string> = new EventEmitter<string>();
    @Output() deleteFormClickEmit: EventEmitter<string> = new EventEmitter<string>();

    onClick() {
        this.clickEmit.emit(this.form.id);
    }

    onDeleteFormClick() {
        this.deleteFormClickEmit.emit(this.form.id);
    }
}
