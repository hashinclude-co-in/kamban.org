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

    this._commonService.loginService('ckind90', 'P@ssword123').subscribe(
      product => {this.accessToken = product.access_token;
    },
      error => {this.errorMessage = <any>error;
        alert(this.errorMessage);
      });
  }
  pageTitle: string = 'localhost';
  userName: string;
  password: string;
  accessToken: string;
  errorMessage: any;

  onLoginClick(): void {
    this._commonService.loginService(this.userName, this.password).subscribe(
      product => {this.accessToken = product.access_token;
    },
      error => {this.errorMessage = <any>error;
        alert(this.errorMessage);
      });
  }

  onLogoutClick(): void {
    this.accessToken = null;
    this._commonService.logoutService();
  }
}
