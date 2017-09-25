import { Component, Input } from '@angular/core';
import { IFormField, IForm } from '../field_template/form-field';

@Component({
    selector: 'pm-form-property',
    templateUrl: './form-property.component.html'
})
export class FormPropertyComponent {
    @Input() value: IForm;
}
