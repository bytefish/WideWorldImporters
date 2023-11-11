// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component } from '@angular/core';
import { ClrDatagridStateInterface } from '@clr/angular';
import { IODataEntitiesResponse } from 'src/app/models/odata-response';
import { Country } from 'src/app/models/entities';
import { ODataService } from 'src/app/services/odata-service';
import { TranslationService } from 'src/app/services/translation.service';
import { ODataUtils } from 'src/app/utils/odata-utils';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-countries-table',
  templateUrl: 'app-countries-table.component.html',
})
export class CountriesTableComponent {

  loading: boolean = true;
  filterOpen: boolean = false;
  tableData: IODataEntitiesResponse<Country> | null;

  constructor(public odataService: ODataService, public translations: TranslationService) {
    this.tableData = null;
  }

  refresh(state: ClrDatagridStateInterface) {
    
    const query = ODataUtils.asODataString(`${environment.baseUrl}/Countries`, state, { $expand: "lastEditedByNavigation" });

    this.loading = true;

    this.odataService.getEntities<Country>(query)
      .subscribe(res => {
        this.tableData = res;
        this.loading = false;
      });
  }
}