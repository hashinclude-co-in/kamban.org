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
  }
  pageTitle: string = 'localhost';
  userName: string = 'ckind90';
  password: string = 'P@ssword123';
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
    localStorage.clear();
  }
}
