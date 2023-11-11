// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule, registerLocaleData } from '@angular/common';
import localeDe from '@angular/common/locales/de';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

// CDS Web Components: 
import '@cds/core/icon/register.js';
import '@cds/core/date/register.js';
import '@cds/core/time/register.js';
import '@cds/core/input/register.js';
import '@cds/core/select/register.js';

import { ClarityIcons, cloudIcon, cogIcon, homeIcon, arrowIcon, worldIcon } from '@cds/core/icon';

// Filters:
import { BooleanFilterComponent } from './components/filters/boolean-filter/boolean-filter.component';
import { DateRangeFilterComponent } from './components/filters/date-range-filter/date-range-filter.component';
import { StringFilterComponent } from './components/filters/string-filter/string-filter-component.component';
import { NumericFilterComponent } from './components/filters/numeric-filter/numeric-filter-component.component';

// Components:
import { ZonedDatePickerComponent } from './components/core/zoned-date-picker.component';
import { CountriesTableComponent } from './components/tables/countries-table/app-countries-table.component';
import { CitiesTableComponent } from './components/tables/cities-table/app-cities-table.component';
import { CustomersTableComponent } from './components/tables/customer-table/app-customer-table.component';

// Add Icons used in the Application:
ClarityIcons.addIcons(homeIcon, cogIcon, cloudIcon, arrowIcon, worldIcon);

registerLocaleData(localeDe);

@NgModule({
  declarations: [
    AppComponent,
    // Common
    ZonedDatePickerComponent,
    // Filter
    BooleanFilterComponent,
    DateRangeFilterComponent,
    NumericFilterComponent,
    StringFilterComponent,
    // Pages
    
    // Tables
    CitiesTableComponent,
    CountriesTableComponent,
    CustomersTableComponent
  ],
  imports: [
    // Angular
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    // Clarity    
    ClarityModule,
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'en' }],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
