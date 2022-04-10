// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component } from '@angular/core';
import { ClrDatagridStateInterface } from '@clr/angular';
import { ODataEntitiesResponse } from 'src/app/models/odata-response';
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
  tableData!: ODataEntitiesResponse<City>;

  constructor(public odataService: ODataService, public translations: TranslationService) {

  }

  refresh(state: ClrDatagridStateInterface) {
    
    const query = ODataUtils.asODataString(`${environment.baseUrl}/Cities`, state, { $expand: "stateProvince, lastEditedByNavigation" });

    this.loading = true;

    this.odataService.getEntities<City>(query)
      .subscribe(res => {
        this.tableData = res;
        this.loading = false;
      });
  }
}