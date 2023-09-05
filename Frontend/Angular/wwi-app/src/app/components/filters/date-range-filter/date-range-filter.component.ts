// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AfterViewInit, Component, Input } from "@angular/core";
import { ClrDatagridFilter, ClrDatagridFilterInterface, ClrPopoverEventsService } from "@clr/angular";
import { Temporal } from "@js-temporal/polyfill";
import { Subject } from "rxjs";
import { ODataFilter, FilterOperator, ColumnFilter, ODataDateFilter } from "src/app/models/filter";
import { TranslationService } from "src/app/services/translation.service";

/**
 * A Component to filter for a Date or a Date Range.
 */
@Component({
    selector: 'app-date-range-filter',
    template: `
            <form clrForm clrLayout="horizontal"  clrLabelSize="4">
                <span class="clr-sr-only">{{translations.keys.filters.dateFilter.screenreader}}<</span>
                <clr-select-container>
                    <label>{{translations.keys.filters.numericFilter.labelOperator}}</label>
                    <select clrSelect name="operators" [(ngModel)]="filterOperator">
                        <option *ngFor="let operator of filterOperators" [value]="operator">{{translations.keys.filterOperators[operator]}}</option>
                    </select>
                </clr-select-container>
                <ng-container *ngIf="isDateRangeFilter; then dateRangeFilter; else dateFilter"></ng-container>
                <ng-template #dateRangeFilter>
                    <clr-control-container>
                        <label>{{translations.keys.filters.dateFilter.labelFrom}}</label>
                        <app-date-picker [(zonedDateTime)]="startDate" [disabled]="isDatePickerDisabled"></app-date-picker>
                    </clr-control-container>
                    <clr-control-container>
                        <label>{{translations.keys.filters.dateFilter.labelTo}}</label>
                        <app-date-picker [(zonedDateTime)]="endDate" [disabled]="isDatePickerDisabled"></app-date-picker>
                    </clr-control-container>
                </ng-template>
                <ng-template #dateFilter>
                    <clr-control-container>
                        <label>{{translations.keys.filters.dateFilter.labelFrom}}</label>
                        <app-date-picker [(zonedDateTime)]="startDate"></app-date-picker>
                    </clr-control-container>
                </ng-template>
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
    styles: ['.filter-actions { margin-top: 1.2rem; }' ]
})
export class DateRangeFilterComponent implements ClrDatagridFilterInterface<any>, AfterViewInit, ColumnFilter  {
    
    /**
     * Filter operators valid for the component.
     */
    readonly filterOperators = [
        FilterOperator.None,
        FilterOperator.IsNull, 
        FilterOperator.IsNotNull, 
        FilterOperator.IsEqualTo, 
        FilterOperator.IsNotEqualTo, 
        FilterOperator.Before, 
        FilterOperator.After, 
        FilterOperator.IsLessThan, 
        FilterOperator.IsLessThanOrEqualTo, 
        FilterOperator.IsGreaterThan, 
        FilterOperator.IsGreaterThanOrEqualTo, 
        FilterOperator.BetweenInclusive, 
        FilterOperator.BetweenExclusive,
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
     * Start Date selected by the user.
     */
    @Input()
    startDate: Temporal.ZonedDateTime |  null = null;

    /**
     * End Date selected by the user.
     */
    @Input()
    endDate: Temporal.ZonedDateTime | null = null;

    /**
     * Required by the ``ClrDatagridFilterInterface`` so the Datagrid knows something has changed.
     */
    changes = new Subject<any>();

    /**
     * Various Filter operators want the Component to show up as a Date Range.
     */
    get isDateRangeFilter(): boolean {
        return this.filterOperator === FilterOperator.None  
            || this.filterOperator === FilterOperator.IsNull
            || this.filterOperator === FilterOperator.IsNotNull
            || this.filterOperator === FilterOperator.BetweenInclusive 
            || this.filterOperator === FilterOperator.BetweenExclusive;
    }

    /**
     * The DatePickers should only be enabled, when we actually need dates. This is not 
     * necessary for ``FilterOperator.Null`` or ``FilterOperator.IsNotNull`` queries.
     */
    get isDatePickerDisabled(): boolean {
        return this.filterOperator === FilterOperator.None || this.filterOperator === FilterOperator.IsNull || this.filterOperator === FilterOperator.IsNotNull;
    }

    /**
     * Creates a new ``DateRangeFilterComponent``.
     * 
     * @param filterContainer - The Clarity Datagrid ``ClrDatagridFilter`` filter container to register to
     * @param translations - Translations to be used in the component.
     * @param clrPopoverEventsService - The popover service to control the behavior of the popout.
     */
    constructor(filterContainer: ClrDatagridFilter, public translations: TranslationService, private clrPopoverEventsService: ClrPopoverEventsService) {
        filterContainer.setFilter(this);
    }

    /**
     * Returns ``true`` if this Filter is enabled.
     * 
     * @returns ``true`` if the Filter is valid.
     */
    isActive(): boolean {
        switch(this.filterOperator) {
            case FilterOperator.None:
                return false;
            case FilterOperator.IsNull:
            case FilterOperator.IsNotNull:
                return true;
            case FilterOperator.IsEqualTo:
            case FilterOperator.IsNotEqualTo:
            case FilterOperator.Before:
            case FilterOperator.After:
            case FilterOperator.IsLessThan:
            case FilterOperator.IsLessThanOrEqualTo:
            case FilterOperator.IsGreaterThan:
            case FilterOperator.IsGreaterThanOrEqualTo:
                return this.startDate != null;
            case FilterOperator.BetweenInclusive:
            case FilterOperator.BetweenExclusive:
                return this.startDate != null && this.endDate != null;
            default:
                throw new Error(`DateFilter does not support ${this.filterOperator}`);
        }
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
     * Resets the Filter.
     */
    resetFilter() {
        this.filterOperator = FilterOperator.None;
        this.startDate = null;
        this.endDate = null;

        // Signal changes:
        this.changes.next(null);
    }

    /**
     * Applies the Filter.
     */
    applyFilter() {
        this.changes.next(null);
    }

    /**
     * Turns this component into an ``ODataFilter``.
     * 
     * @returns The OData Filter for the component.
     */
    toODataFilter(): ODataFilter {
        return new ODataDateFilter(this.field, this.filterOperator, this.startDate, this.endDate);
    }

    /**
     * After the Component has been initialized we need to tell its ``ClrPopoverEventsService`` to 
     * not close, when the User has accidentally clicked outside the filter. And if the Filter has been 
     * initialized, we tell the Datagrid to refresh the filters.
     */
    ngAfterViewInit() {
		this.clrPopoverEventsService.outsideClickClose = false;

        if(this.isActive()) {
            this.applyFilter();
        }
	}
}