import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { HttpHeaders } from '@angular/common/http';
import { ICookie } from './cookie-template';


@Injectable()
export class CommonService {

    cookie: ICookie = null;
    baseURL: string = 'http://localhost:61799/';
    // baseURL: string = 'http://kbn.azurewebsites.net';
    constructor(private _http: HttpClient) {
    }

    loginService(_userName: string, _password: string): Observable<ICookie> {
        const body = 'grant_type=password&username=' + _userName + '&password=' + _password;
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        return this._http.post(this.baseURL + 'token',
            body, {
                headers: headers
            })
            .do(data => {
                this.cookie = <ICookie> data;
                localStorage.setItem('auth_token', this.cookie.access_token);
            })
            .catch(this.handleError);
    }

    logoutService(): boolean {
        this.cookie = null;
        return true;
    }

    getAccessToken(): string {
        if (this.cookie !== null && this.cookie.access_token !== null) {
            return this.cookie.access_token;
        }
        return null;
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
    }
}
