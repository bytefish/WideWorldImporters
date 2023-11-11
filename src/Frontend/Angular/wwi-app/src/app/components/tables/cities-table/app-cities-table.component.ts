// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component } from '@angular/core';
import { ClrDatagridStateInterface } from '@clr/angular';
import { IODataEntitiesResponse, ODataEntitiesResponse } from 'src/app/models/odata-response';
import { City } from 'src/app/models/entities';
import { ODataService } from 'src/app/services/odata-service';
import { TranslationService } from 'src/app/services/translation.service';
import { ODataUtils } from 'src/app/utils/odata-utils';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cities-table',
  templateUrl: 'app-cities-table.component.html',
})
export class CitiesTableComponent {

  loading: boolean = true;
  filterOpen: boolean = false;
  tableData: IODataEntitiesResponse<City> | null;

  constructor(public odataService: ODataService, public translations: TranslationService) {
    this.tableData = null;
  }

  refresh(state: ClrDatagridStateInterface) {

    const query = ODataUtils.asODataString(`${environment.baseUrl}/Cities`, state, { $expand: "stateProvince, lastEditedByNavigation" });

    this.odataService.executeUpdate(`${environment.baseUrl}/Cities`, {

    });

    this.loading = true;

    this.odataService.getEntities<City>(query)
      .subscribe(res => {
        this.tableData = res; 
        this.loading = false;
        
        console.log(res.entities[0]);

        this.odataService.executeUpdate(`${environment.baseUrl}/Cities(${res.entities[0].cityId})`, {
          "CityName": "Test"
        }).subscribe(x => console.log(x));
    

      });

    // Temporary Batching Example
    //
    //const query2 = `${environment.baseUrl}/Cities(30)`;
    //
    //const batchEndpoint = `${environment.baseUrl}/$batch`;
    //
    //this.odataService.executeBatch(batchEndpoint, [
    //  { 
    //    id: "1",
    //    method: "GET",
    //    url: query
    //  },
    //  { 
    //    id: "2",
    //    method: "GET",
    //    url: query2
    //  },
    //]).subscribe(x => {
    //  console.log(x.getODataEntitiesResponse("1"));
    //  console.log(x.getODataEntityResponse("2"));
    //});

  }
}