// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component, Input } from "@angular/core";
import { ClrDatagridFilter, ClrDatagridFilterInterface, ClrPopoverEventsService } from "@clr/angular";
import { Subject } from "rxjs";
import { ODataFilter, FilterOperator, ColumnFilter, ODataBooleanFilter } from "src/app/models/filter";
import { TranslationService } from "src/app/services/translation.service";

/**
 * A Filter for Boolean values.
 */
@Component({
    selector: 'app-boolean-filter',
    template: `
        <form clrForm  clrLayout="horizontal"  clrLabelSize="4">
            <clr-select-container>
                <label>{{translations.keys.filters.booleanFilter.labelOperator}}</label>
                <select clrSelect name="operators" [(ngModel)]="filterOperator">
                    <option *ngFor="let operator of filterOperators" [value]="operator">{{translations.keys.filterOperators[operator]}}</option>
                </select>
            </clr-select-container>
            <div class="clr-row filter-actions">
                <div class="clr-col">
                    <button class="btn btn-primary btn-block" (click)="applyFilter()">{{translations.keys.filters.applyFilter}}</button>
                </div>
                <div class="clr-col">
                    <button class="btn btn-block" (click)="resetFilter()">{{translations.keys.filters.resetFilter}}</button>
                </div>
            </div>
        </form>
    `,
    styles: ['.filter-actions { margin-top: 1.2rem; }']
})
export class BooleanFilterComponent implements ClrDatagridFilterInterface<any>, ColumnFilter  {
   
    /**
     * Filter operators valid for the component.
     */
    readonly filterOperators = [
        FilterOperator.None,
        FilterOperator.All, 
        FilterOperator.Yes, 
        FilterOperator.No, 
        FilterOperator.IsNull, 
        FilterOperator.IsNotNull
    ];

    /**
     * The name of the field, which has to match the model.
     */
    @Input()
    field!: string;

    /**
     * The Filter operator selected by the user.
     */
    @Input()
    filterOperator: FilterOperator = FilterOperator.All;

    /**
     * Required by the ``ClrDatagridFilterInterface`` so the Datagrid knows something has changed.
     */
    changes = new Subject<any>();

    /**
     * Creates a new ``BooleanFilterComponent``.
     * 
     * @param filterContainer - The Clarity Datagrid ``ClrDatagridFilter`` filter container to register to
     * @param translations - Translations to be used in the component.
     * @param clrPopoverEventsService - The popover service to control the behavior of the popout.
     */
    constructor(filterContainer: ClrDatagridFilter, public translations: TranslationService, private clrPopoverEventsService: ClrPopoverEventsService) {
        filterContainer.setFilter(this);
    }

    /**
     * Applies the Filter.
     */
    applyFilter(): void {
        this.changes.next(null);
    }

    /**
     * Resets the Filter.
     */
    resetFilter(): void {
        this.filterOperator = FilterOperator.None;

        this.changes.next(null);
    }

    /**
     * Turns this component into an ``ODataFilter``.
     * 
     * @returns The OData Filter for the component.
     */
    toODataFilter(): ODataFilter {
        return new ODataBooleanFilter(this.field, this.filterOperator);
    }

    /**
     * Returns ``true`` if this Filter is enabled.
     * 
     * @returns ``true`` if the Filter is valid.
     */
    isActive(): boolean {
        return this.filterOperator !== FilterOperator.None;;
    }
    
    /**
     * This method needs to be implemented for Client-side Filtering. We will do all 
     * filtering on Server-side and just pipe everything through here.
     * 
     * @param item - Item to Filter for
     * @returns At the moment this method only returns ``true``
     */
    accepts(item: any): boolean {
        return true;
    }

    /**
     * After the Component has been initialized we need to tell its ``ClrPopoverEventsService`` to 
     * not close, when the User has accidentally clicked outside the filter. And if the Filter has been 
     * initialized, we tell the Datagrid to refresh the filters.
     */
    ngAfterViewInit() {
		this.clrPopoverEventsService.outsideClickClose = false;

        if(this.filterOperator != FilterOperator.None) {
            this.applyFilter();
        }
	}
}