// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AfterViewInit, Component, Input } from "@angular/core";
import { ClrDatagridFilter, ClrDatagridFilterInterface, ClrPopoverEventsService } from "@clr/angular";
import { Subject } from "rxjs";
import { ODataFilter, FilterOperator, FilterType, ColumnFilter, ODataStringFilter } from "src/app/models/filter";
import { TranslationService } from "src/app/services/translation.service";

/**
 * A Filter for search string values.
 */
@Component({
    selector: 'app-string-filter',
    template: `
        <form clrForm clrLayout="horizontal"  clrLabelSize="4">
        <clr-select-container>
                <label>{{translations.keys.filters.numericFilter.labelOperator}}</label>
                <select clrSelect name="operators" [(ngModel)]="filterOperator">
                    <option *ngFor="let operator of filterOperators" [value]="operator">{{translations.keys.filterOperators[operator]}}</option>
                </select>
            </clr-select-container>
            <clr-input-container>
                <label>{{translations.keys.filters.numericFilter.labelValue}}</label>
                <input clrInput [placeholder]="translations.keys.filters.stringFilter.placeholder" name="input" [(ngModel)]="search" 
                    [disabled]="filterOperator === 'none' || filterOperator === 'isNull' || filterOperator === 'isNotNull' || filterOperator === 'isEmpty' || filterOperator === 'isNotEmpty'" />
            </clr-input-container>
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
export class StringFilterComponent implements ClrDatagridFilterInterface<any>, ColumnFilter, AfterViewInit  {

    /**
     * Filter operators valid for the component.
     */
    readonly filterOperators: FilterOperator[] = [
        FilterOperator.None,
        FilterOperator.IsNull, 
        FilterOperator.IsNotNull, 
        FilterOperator.IsEmpty, 
        FilterOperator.IsNotEmpty, 
        FilterOperator.IsEqualTo, 
        FilterOperator.IsNotEqualTo, 
        FilterOperator.Contains, 
        FilterOperator.NotContains, 
        FilterOperator.StartsWith, 
        FilterOperator.EndsWith,
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
    filterOperator: FilterOperator = FilterOperator.None;
 

    /**
     * Search Value entered by the user.
     */
    @Input()
    search: string | null = null;

    /**
     * Required by the ``ClrDatagridFilterInterface`` so the Datagrid knows something has changed.
     */
    changes = new Subject<any>();

    /**
     * Creates a new ``StringFilterComponent``.
     * 
     * @param filterContainer - The Clarity Datagrid ``ClrDatagridFilter`` filter container to register to
     * @param translations - Translations to be used in the component.
     * @param clrPopoverEventsService - The popover service to control the behavior of the popout.
     */
    constructor(private filterContainer: ClrDatagridFilter, public translations: TranslationService, private clrPopoverEventsService: ClrPopoverEventsService) {
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
        this.search = null;

        this.changes.next(null);
    }

    /**
     * Returns ``true`` if this Filter is enabled.
     * 
     * @returns ``true`` if the Filter is valid.
     */
    isActive(): boolean {
        return this.filterOperator !== FilterOperator.None;
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
     * Turns this component into an ``ODataFilter``.
     * 
     * @returns The OData Filter for the component.
     */
    toODataFilter(): ODataFilter {
        return new ODataStringFilter(this.field, this.filterOperator, this.search);
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