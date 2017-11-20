import { Component } from '@angular/core';
import { FormsService } from './forms/forms.service';
import { CommonService } from './shared/common.service';

@Component({
  selector: 'pm-root',
  templateUrl: './app.component.html',
  providers: [FormsService]
})
export class AppComponent {
  constructor(private _commonService: CommonService) {
    this.userName = '';
    this.password = '';
    this.accessToken = 'Dummy';
  }
  pageTitle: string = 'Kamban';
  userName: string;
  password: string;
  accessToken: string;
  errorMessage: any;

  onLoginClick(): void {
    // this._commonService.getAccessToken(this.userName, this.password);
    this._commonService.loginService(this.userName, this.password).subscribe(
      product => {this.accessToken = product.access_token;
      alert(this.accessToken);
    },
      error => {this.errorMessage = <any>error;
        alert(this.errorMessage);
      });

      // this._commonService.getValues().subscribe(
      //   product => this.accessToken = product,
      //   error => this.errorMessage = <any>error);
  }
}
