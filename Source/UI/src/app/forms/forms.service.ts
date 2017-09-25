import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { IFormField, IForm } from './field_template/form-field';

@Injectable()
export class FormsService {
    private _productUrl = './api/products/forms.json';

    private _forms: IForm[] = [];
    private _form: IForm;

    constructor(private _http: HttpClient) { }

    getAllProducts(): IFormField[] {
        return [
            {
                index: 0,
                title: '',
                value: '',
                instruction: '',
                mandatory: true,
                type: ''
            },
            {
                index: 0,
                title: '',
                value: '',
                instruction: '',
                mandatory: true,
                type: ''
            }
        ];
    }

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

    addNewForm(form: IForm): string {
        // TODO - Create new form, add it to the DB and return form user name
        this._form = form;
        this._form.id = form.title.replace(/ /g, '');
        this._forms.push(this._form);
        return this._form.id;
    }

    getForm(formId: string): IForm {
        return this._forms.filter(x => x.id === formId)[0];
    }
}
