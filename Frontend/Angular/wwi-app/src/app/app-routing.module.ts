// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/app-home.component';
import { CitiesTableComponent } from './components/tables/cities-table/app-cities-table.component';
import { CountriesTableComponent } from './components/tables/countries-table/app-countries-table.component';
import { CustomersTableComponent } from './components/tables/customer-table/app-customer-table.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'tables/cities', component: CitiesTableComponent },
  { path: 'tables/countries', component: CountriesTableComponent },
  { path: 'tables/customers', component: CustomersTableComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
