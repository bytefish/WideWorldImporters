// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AfterViewInit, Component, Input } from "@angular/core";
import { ClrDatagridFilter, ClrDatagridFilterInterface, ClrPopoverEventsService } from "@clr/angular";
import { Subject } from "rxjs";
import { ODataFilter, FilterOperator, ColumnFilter, ODataNumericFilter } from "src/app/models/filter";
import { TranslationService } from "src/app/services/translation.service";

/**
 * A Filter to search for Numeric values within a specified range.
 */
@Component({
    selector: 'app-numeric-filter',
    template: `
        <form clrForm  clrLayout="horizontal"  clrLabelSize="4">
            <clr-select-container>
                <label>{{translations.keys.filters.numericFilter.labelOperator}}</label>
                <select clrSelect name="operators" [(ngModel)]="filterOperator">
                    <option *ngFor="let operator of filterOperators" [value]="operator">{{translations.keys.filterOperators[operator]}}</option>
                </select>
            </clr-select-container>

            <ng-container *ngIf="isNumericRangeFilter; then rangeValueFilter; else singleValueFilter"></ng-container>

            <ng-template #singleValueFilter>
                <clr-input-container>
                    <label>{{translations.keys.filters.numericFilter.labelValue}}</label>
                    <input clrInput [placeholder]="translations.keys.filters.numericFilter.placeholder" name="input" [(ngModel)]="low" />
                </clr-input-container>
            </ng-template>
        
            <ng-template #rangeValueFilter>
                <clr-input-container>
                    <label>{{translations.keys.filters.numericFilter.labelLow}}</label>
                    <input clrInput [placeholder]="translations.keys.filters.numericFilter.placeholder" name="input" [(ngModel)]="low" 
                        [disabled]="filterOperator === 'none' || filterOperator === 'isNull' || filterOperator === 'isNotNull'" />
                </clr-input-container>
                <clr-input-container>
                    <label>{{translations.keys.filters.numericFilter.labelHigh}}</label>
                    <input clrInput [placeholder]="translations.keys.filters.numericFilter.placeholder" name="input" [(ngModel)]="high" 
                        [disabled]="filterOperator === 'none' || filterOperator === 'isNull' || filterOperator === 'isNotNull'" />
                </clr-input-container>
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
    styles: ['.filter-actions { margin-top: 1.2rem; }']
})
export class NumericFilterComponent implements ClrDatagridFilterInterface<any>, ColumnFilter, AfterViewInit {

    /**
     * Filter operators valid for the component.
     */
    readonly filterOperators: FilterOperator[] = [
        FilterOperator.None,
        FilterOperator.IsNull, 
        FilterOperator.IsNotNull, 
        FilterOperator.IsEqualTo, 
        FilterOperator.IsNotEqualTo, 
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
     * The Lower range entered by the user.
     */
    @Input()
    low: number | null = null;

    /**
     * The Upper Range entered by the user.
     */
    @Input()
    high: number | null = null;

    /**
     * Required by the ``ClrDatagridFilterInterface`` so the Datagrid knows something has changed.
     */
    changes = new Subject<any>();

    /**
     * Creates a new ``NumericRangeFilterComponent``.
     * 
     * @param filterContainer - The Clarity Datagrid ``ClrDatagridFilter`` filter container to register to
     * @param translations - Translations to be used in the component.
     * @param clrPopoverEventsService - The popover service to control the behavior of the popout.
     */
    constructor(filterContainer: ClrDatagridFilter, public translations: TranslationService, private clrPopoverEventsService: ClrPopoverEventsService) {
        filterContainer.setFilter(this);
    }

    /**
     * Some operators want the Component to show up as a Numeric Range, such as ``FilterOperator.BetweenInclusive`` and ``FilterOperator.BetweenExclusive``.
     */
    get isNumericRangeFilter(): boolean {
        return this.filterOperator === FilterOperator.None 
            || this.filterOperator === FilterOperator.IsNull
            || this.filterOperator === FilterOperator.IsNotNull
            || this.filterOperator === FilterOperator.BetweenInclusive 
            || this.filterOperator === FilterOperator.BetweenExclusive;
    };

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
        this.low = null;
        this.high = null;

        this.changes.next(null);
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
            case FilterOperator.IsLessThan:
            case FilterOperator.IsLessThanOrEqualTo:
            case FilterOperator.IsGreaterThan:
            case FilterOperator.IsGreaterThanOrEqualTo:
                return this.low != null;
            case FilterOperator.BetweenInclusive:
            case FilterOperator.BetweenExclusive:
                return this.low != null && this.high != null;
            default:
                throw new Error(`${this.filterOperator} is not supported`);
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
     * Turns this component into an ``ODataFilter``.
     * 
     * @returns The OData Filter for the component.
     */
    toODataFilter(): ODataFilter {
        return new ODataNumericFilter(this.field, this.filterOperator, this.low, this.high);
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