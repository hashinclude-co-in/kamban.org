import { Component, Input } from '@angular/core';
import { IFormField } from '../field_template/form-field';

@Component({
    selector: 'pm-form-property',
    templateUrl: './form-property.component.html'
})
export class FormPropertyComponent {
    @Input() value: IFormField;
}
