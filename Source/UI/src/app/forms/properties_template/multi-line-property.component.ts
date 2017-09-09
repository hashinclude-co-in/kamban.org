import { Component, Input } from '@angular/core';
import { IFormField } from '../field_template/form-field';

@Component({
    selector: 'pm-multi-line-property',
    templateUrl: './multi-line-property.component.html'
})
export class MultiLinePropertyComponent {
    @Input() value: IFormField;
}
