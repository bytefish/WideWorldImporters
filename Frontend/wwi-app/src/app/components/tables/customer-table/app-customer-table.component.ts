// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component } from '@angular/core';
import { ClrDatagridStateInterface } from '@clr/angular';
import { ODataEntitiesResponse } from 'src/app/models/odata-response';
import { Customer } from 'src/app/models/entities';
import { ODataService } from 'src/app/services/odata-service';
import { TranslationService } from 'src/app/services/translation.service';
import { ODataUtils } from 'src/app/utils/odata-utils';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-customer-table',
  templateUrl: 'app-customer-table.component.html',
})
export class CustomersTableComponent {

  loading: boolean = true;
  filterOpen: boolean = false;
  tableData: ODataEntitiesResponse<Customer> | null;

  constructor(public odataService: ODataService, public translations: TranslationService) {
    this.tableData = null;
  }

  refresh(state: ClrDatagridStateInterface) {
    
    const query = ODataUtils.asODataString(`${environment.baseUrl}/Customers`, state, { $expand: "lastEditedByNavigation" });

    this.loading = true;

    this.odataService.getEntities<Customer>(query)
      .subscribe(res => {
        this.tableData = res;
        this.loading = false;
      });
  }
}