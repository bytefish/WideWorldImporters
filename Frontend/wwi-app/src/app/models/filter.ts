// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Temporal } from "@js-temporal/polyfill";

// Each Filter has a Type:
export enum FilterType {
    NumericFilter = "numericFilter",
    StringFilter = "stringFilter",
    DateFilter = "dateFilter",
    BooleanFilter = "booleanFilter",
};

// All Filters share a common set of FilterOperators, such as "Greater Than"...
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

// We need a way to return a Filter for each column:
export interface ColumnFilter {

    // Field.
    field: string;

    // FilterOperator.
    filterOperator: FilterOperator;

    // Applies a Filter
    applyFilter(): void;

    // Resets a Filter
    resetFilter(): void;

    // Returns a Filter
    toODataFilter(): ODataFilter;
}

// Every OData Filter is applied to a specific field and provides a way to 
// serialize itself into the OData Format:
export interface ODataFilter {

    // Field to Filter.
    field: string;

    // Operator.
    operator: FilterOperator;

    // Serializes the OData Filter.
    toODataString(): string | null;
};

// A Filter on Strings:
export class ODataStringFilter implements ODataFilter {

    field: string;
    operator: FilterOperator;
    value: string | null;

    constructor(field: string, operator: FilterOperator, value: string | null) {
        this.field = field;
        this.operator = operator;
        this.value = value;
    }

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

// A Filter on Dates and Date Ranges:
export class ODataDateFilter implements ODataFilter {

    readonly field: string;
    readonly operator: FilterOperator;
    readonly startDate: Temporal.ZonedDateTime | null;
    readonly endDate: Temporal.ZonedDateTime | null;

    constructor(field: string, operator: FilterOperator, startDate: Temporal.ZonedDateTime | null, endDate: Temporal.ZonedDateTime | null) {
        this.field = field;
        this.operator = operator;
        this.startDate = startDate;
        this.endDate = endDate;
    }

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

// A Filter on Boolean Values:
export class ODataBooleanFilter implements ODataFilter {

    readonly field: string;
    readonly operator: FilterOperator;

    constructor(field: string, operator: FilterOperator) {
        this.field = field;
        this.operator = operator;
    }

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

// A Filter on Numeric Values:
export class ODataNumericFilter implements ODataFilter {

    readonly field: string;
    readonly operator: FilterOperator;
    readonly low: number | null;
    readonly high: number | null;

    constructor(field: string, operator: FilterOperator, low: number | null, high: number | null) {
        this.field = field;
        this.operator = operator;
        this.low = low;
        this.high = high;
    }

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
