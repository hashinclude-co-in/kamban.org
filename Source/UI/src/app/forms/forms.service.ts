import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { IFormField, IForm } from './field_template/form-field';
import { CommonService } from '../shared/common.service';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class FormsService {
    private _productUrl = './api/products/forms.json';

    private _forms: IForm[] = [];
    private _form: IForm;

    constructor(private _http: HttpClient,
        private _commonService: CommonService) { }


    getProducts(): Observable<IFormField[]> {
        return this._http.get<IFormField[]>(this._productUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getProduct(id: number): Observable<IFormField> {
        return this.getProducts()
            .map((products: IFormField[]) => products.find(p => p.index === id));
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

    addNewForm(form: IForm): Observable<string> {
        this._form = form;

        const body = form;
        const authToken = this._commonService.getAccessToken();
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${authToken}` });
        headers.append('Content-Type', 'application/json');

        return this._http.post(this._commonService.baseURL + 'api/forms',
            body, {
                headers: headers
            })
            .do(data => {
                this._forms.push(this._form);
                return this._form.id;
            })
            .catch(this.handleError);
    }

    getForm(formId: string): Observable<IForm> {

        const authToken = this._commonService.getAccessToken();
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${authToken}` });
        headers.append('Content-Type', 'application/json');

        return this._http.get<IForm>(this._commonService.baseURL + 'api/forms/' + formId,
            {
                headers: headers
            })
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    updateForm(form: IForm): Observable<boolean> {
        const body = form;
        const authToken = this._commonService.getAccessToken();
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${authToken}` });
        headers.append('Content-Type', 'application/json');

        return this._http.patch<boolean>(this._commonService.baseURL + 'api/forms/',
            body,
            {
                headers: headers
            })
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    deleteForm(formid: string): Observable<boolean> {

        const authToken = this._commonService.getAccessToken();
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${authToken}` });
        headers.append('Content-Type', 'application/json');

        return this._http.delete<boolean>(this._commonService.baseURL + 'api/forms/' + formid,
            {
                headers: headers
            })
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    deleteFormField(formid: string, formFieldId: string): Observable<boolean> {

        const authToken = this._commonService.getAccessToken();
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${authToken}` });
        headers.append('Content-Type', 'application/json');

        return this._http.delete<boolean>(this._commonService.baseURL + 'api/forms/' + formid + '/' + formFieldId,
            {
                headers: headers
            })
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    getAllForms(): Observable<IForm[]> {
        const authToken = this._commonService.getAccessToken();
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${authToken}` });
        headers.append('Content-Type', 'application/json');

        return this._http.get<IForm[]>(this._commonService.baseURL + 'api/forms',
            {
                headers: headers
            })
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
}
