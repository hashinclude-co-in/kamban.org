import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './home/welcome.component';
import { ProductModule } from './products/product.module';
import { NewFormComponent } from './forms/new-form.component';
import { PropertyWindowComponent } from './forms/properties_template/property-window.component';
import { SingleLineComponent } from './forms/field_template/single-line.component';
import { MultiLineComponent } from './forms/field_template/multi-line.component';
import { SingleLinePropertyComponent } from './forms/properties_template/single-line-property.component';
import { MultiLinePropertyComponent } from './forms/properties_template/multi-line-property.component';
import { FormsModule } from '@angular/forms';
import { NewFieldTemplateComponent } from './forms/field_template/new-field-template.component';
import { FormPropertyComponent } from './forms/properties_template/form-property.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    NewFormComponent,
    PropertyWindowComponent,
    SingleLineComponent,
    MultiLineComponent,
    MultiLinePropertyComponent,
    SingleLinePropertyComponent,
    NewFieldTemplateComponent,
    FormPropertyComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
        { path: '', component: WelcomeComponent },
        { path: '**', redirectTo: '', pathMatch: 'full'}
    ]),
    ProductModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
