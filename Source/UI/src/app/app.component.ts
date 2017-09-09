import { Component } from '@angular/core';
import { FormsService } from './forms/forms.service';

@Component({
  selector: 'pm-root',
  templateUrl: './app.component.html',
  providers: [ FormsService ]
})
export class AppComponent {
  pageTitle: string = 'Kamban';
}
