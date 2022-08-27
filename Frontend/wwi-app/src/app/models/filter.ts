// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Temporal } from "@js-temporal/polyfill";

/**
 * Each Filter has a Type.
 */
export enum FilterType {
    NumericFilter = "numericFilter",
    StringFilter = "stringFilter",
    DateFilter = "dateFilter",
    BooleanFilter = "booleanFilter",
};

/**
 * All Filters share a common set of FilterOperators, such as "Greater Than"...
 */
export enum FilterOperator {
    None = "none",
    Before = "before",
    After = "after",
    IsEqualTo = "isEqualTo",
    IsNotEqualTo = "isNotEqualTo",
    Contains = "contains",
    NotContains = "notContains",
    StartsWith = "startsWith",
    EndsWith = "endsWith",
    IsNull = "isNull",
    IsNotNull = "isNotNull",
    IsEmpty = "isEmpty",
    IsNotEmpty = "isNotEmpty",
    IsGreaterThanOrEqualTo = "isGreaterThanOrEqualTo",
    IsGreaterThan = "isGreaterThan",
    IsLessThanOrEqualTo = "isLessThanOrEqualTo",
    IsLessThan = "isLessThan",
    BetweenInclusive = "betweenInclusive",
    BetweenExclusive = "betweenExclusive",
    Yes = "yes",
    No = "no",
    All = "all"
};

/**
 * A Column Filter is applied to a field and knows 
 */
export interface ColumnFilter {

    /**
     * Field to apply the Filter on.
     */
    field: string;

    /**
     * Filter operator, such as "IsNull", "StartsWith", ...
     */
    filterOperator: FilterOperator;

    /**
     * Applies the Filter.
     */
    applyFilter(): void;

    /**
     * Resets the Filter.
     */
    resetFilter(): void;

    /**
     * Returns the OData Filter.
     */
    toODataFilter(): ODataFilter;
}


/**
 * Every OData Filter is applied to a field and provides a way to serialize itself into the OData Format.
 */
export interface ODataFilter {

    /**
     * Field to apply the Filter on.
     */
    field: string;

    /**
     * The Filter operator, such as "IsNull", "StartsWith", ...
     */
    operator: FilterOperator;

    /**
     * Serializes the ODataFilter as a string.
     */
    toODataString(): string | null;
};

/**
 * OData Filter on a String field.
 */
export class ODataStringFilter implements ODataFilter {

    /**
     * Field to apply the Filter on.
     */
    field: string;
    
    /**
     * Operator to filter for.
     */
    operator: FilterOperator;

    /**
     * The Value to filter.
     */
    value: string | null;

    /**
     * Constructs a new ``StringFilter``.
     * 
     * @param field - Field to apply the Filter on.
     * @param operator - Operator to filter for, such as "IsNull", "StartsWith", ...
     * @param value - The Value to filter for.
     */
    constructor(field: string, operator: FilterOperator, value: string | null) {
        this.field = field;
        this.operator = operator;
        this.value = value;
    }

    /**
     * Converts this Filter to an OData string.
     * 
     * @returns OData filter string for the field.
     */
    toODataString(): string | null {

        if (this.operator == FilterOperator.None) {
            return null;
        }
   
        switch (this.operator) {
            case FilterOperator.IsNull:
                return `${this.field} eq null`;
            case FilterOperator.IsNotNull:
                return `${this.field} ne null`;
            case FilterOperator.IsEqualTo:
                return `${this.field}  eq '${this.value}'`;
            case FilterOperator.IsNotEqualTo:
                return `${this.field} neq '${this.value}'`;
            case FilterOperator.IsEmpty:
                return `(${this.field} eq null) or (${this.field} eq '')`
            case FilterOperator.IsNotEmpty:
                return `(${this.field} ne null) and (${this.field} ne '')`
            case FilterOperator.Contains:
                return `contains(${this.field}, '${this.value}')`;
            case FilterOperator.NotContains:
                return `indexof(${this.field}, '${this.value}') eq -1`;
            case FilterOperator.StartsWith:
                return `startswith(${this.field}, '${this.value}')`;
            case FilterOperator.EndsWith:
                return `endswith(${this.field}, '${this.value}')`;
            default:
                throw new Error(`${this.operator} is not supported`);
        }
    }
}

/**
 * A Filter for dates and date range queries.
 */
export class ODataDateFilter implements ODataFilter {

    /**
     * The field to apply the filter on.
     */
    readonly field: string;

    /**
     * The filter operator to apply, such as "IsNull", "StartsWith", ...
     */
    readonly operator: FilterOperator;

    /**
     * The start date for a range query.
     */
    readonly startDate: Temporal.ZonedDateTime | null;

    /**
     * The end date for a range query.
     */
    readonly endDate: Temporal.ZonedDateTime | null;

    /**
     * Builds a new Date Filter.
     * 
     * @param field - The field to apply the filter on. 
     * @param operator - The filter operator to apply, such as "IsNull", "StartsWith", ...
     * @param startDate - The start date for a range query.
     * @param endDate - The end date for a range query.
     */
    constructor(field: string, operator: FilterOperator, startDate: Temporal.ZonedDateTime | null, endDate: Temporal.ZonedDateTime | null) {
        this.field = field;
        this.operator = operator;
        this.startDate = startDate;
        this.endDate = endDate;
    }

    /**
     * Converts this Filter to an OData string.
     * 
     * @returns OData filter string for the field.
     */
    toODataString(): string | null {

        if (this.operator == FilterOperator.None) {
            return null;
        }

        const startDate = this.toODataDateTime(this.startDate);
        const endDate =  this.toODataDateTime(this.endDate);

        switch (this.operator) {
            case FilterOperator.IsNull:
                return `${this.field} eq null`;
            case FilterOperator.IsNotNull:
                return `${this.field} ne null`;
            case FilterOperator.IsEqualTo:
                return `${this.field}  eq ${startDate}`;
            case FilterOperator.IsNotEqualTo:
                return `${this.field}  neq ${startDate}`;
            case FilterOperator.After:
            case FilterOperator.IsGreaterThan:
                return `${this.field} gt ${startDate}`;
            case FilterOperator.IsGreaterThanOrEqualTo:
                return `${this.field} ge ${startDate}`;
            case FilterOperator.Before:
            case FilterOperator.IsLessThan:
                return `${this.field} lt ${startDate}`;
            case FilterOperator.IsLessThanOrEqualTo:
                return `${this.field} le ${startDate}`;
            case FilterOperator.BetweenExclusive:
                return `(${this.field} gt ${startDate}) and (${this.field} lt ${endDate})`;
            case FilterOperator.BetweenInclusive:
                return `(${this.field} ge ${startDate}) and (${this.field} le ${endDate})`;
            default:
                throw new Error(`${this.operator} is not supported`);
        }
    }

    /**
     * Converts the ``ZonedDateTime`` into an OData-compatible string. OData needs 
     * Dates to be formatted in UTC (Zulu) ISO format.
     * 
     * @param zonedDateTime - The ``ZonedDateTime`` to filter for.
     * @returns OData representation for the ``ZonedDateTime``
     */
    toODataDateTime(zonedDateTime: Temporal.ZonedDateTime | null): string | null {
        if(zonedDateTime == null) {
            return null;
        }

        const utcZonedDateTimeString = zonedDateTime
            .withTimeZone('UTC')
            .toString({ smallestUnit: 'seconds', timeZoneName: 'never', offset: 'never'});
        
        return `${utcZonedDateTimeString}Z`;
    }
};

/**
 * A Filter for for boolean values.
 */
export class ODataBooleanFilter implements ODataFilter {

    /**
     * The field to apply the filter on.
     */
    readonly field: string;

    /**
     * The filter operator to apply, such as "Yes", "No", ...
     */
    readonly operator: FilterOperator;

    /**
     * 
     * @param field - The field to apply the filter on.
     * @param operator - The filter operator to apply, such as "Yes", "No", ...
     */
    constructor(field: string, operator: FilterOperator) {
        this.field = field;
        this.operator = operator;
    }

    /**
     * Converts this Filter to an OData string.
     * 
     * @returns OData filter string for the field.
     */
    toODataString(): string | null {
        
        if (this.operator == FilterOperator.None) {
            return null;
        }

        switch (this.operator) {
            case FilterOperator.IsNull:
                return `${this.field} eq null`;
            case FilterOperator.IsNotNull:
                return `${this.field} ne null`;
            case FilterOperator.Yes:
                return `${this.field} eq true`;
            case FilterOperator.No:
                return `${this.field} eq false`;
            default:
                return null;
        }
    }
}

/**
 *  A Filter for numeric values and range queries.
 */
export class ODataNumericFilter implements ODataFilter {

    /**
     * The field to apply the filter on. 
     */
    readonly field: string;

    /**
     * The filter operator to apply, such as "IsNull", "LessThan", ...
     */
    readonly operator: FilterOperator;

    /**
     * Lower Bound for range queries.
     */
    readonly low: number | null;

    /**
     * Upper Bound for Range Queries.
     */
    readonly high: number | null;

    /**
     * 
     * @param field - The field to apply the filter on. 
     * @param operator - The filter operator to apply, such as "IsNull", "LessThan", ...
     * @param low - Lower Bound for range queries.
     * @param high - Upper Bound for Range Queries.
     */
    constructor(field: string, operator: FilterOperator, low: number | null, high: number | null) {
        this.field = field;
        this.operator = operator;
        this.low = low;
        this.high = high;
    }

    /**
     * Converts this Filter to an OData string.
     * 
     * @returns OData filter string for the field.
     */
    toODataString(): string | null {

        if (this.operator == FilterOperator.None) {
            return null;
        }

        switch (this.operator) {
            case FilterOperator.IsNull:
                return `${this.field} eq null`;
            case FilterOperator.IsNotNull:
                return `${this.field} ne null`;
            case FilterOperator.IsGreaterThan:
                return `${this.field} gt ${this.low}`; 
            case FilterOperator.IsGreaterThanOrEqualTo:
                return `${this.field} ge ${this.low}`;
            case FilterOperator.IsLessThan:
                return `${this.field} lt ${this.low}`;
            case FilterOperator.IsLessThan:
                return `${this.field} le ${this.low}`;
            case FilterOperator.BetweenExclusive:
                return `(${this.field} gt ${this.low}) and (${this.field} lt ${this.high})`;
            case FilterOperator.BetweenInclusive:
                return `(${this.field} ge ${this.low}) and (${this.field} le ${this.high})`;
            default:
                return null;
        }
    }
}
