// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Temporal } from '@js-temporal/polyfill';
import { DefaultZonedDatePickerConfiguration, isTimeZoneSupported, ZonedDatePickerConfiguration } from "src/app/data/app-timezones";

/**
 * A ZonedDatePickerComponent provides a way to select a Plain DateTime and TimeZone.
 */
@Component({
    selector: 'app-date-picker',
    template: `
        <div cds-layout="vertical gap:lg">
            <cds-input-group layout="vertical" control-width="shrink">
                <cds-date>
                    <label>{{zonedDateTimePickerConfiguration.labels.labelDate}}</label>
                    <input type="date" [value]="dateString" (change)="onDateChange($event)" [disabled]="disabled" />
                </cds-date>
                <cds-time>
                    <label>{{zonedDateTimePickerConfiguration.labels.labelTime}}</label>
                    <input [disabled]="disabled" type="time" [value]="timeString" (change)="onTimeChange($event)" />
                </cds-time>
                <cds-select>
                    <label>{{zonedDateTimePickerConfiguration.labels.labelTimeZone}}</label>
                    <select [(ngModel)]="timeZone" (change)="onTimeZoneChange($event)" [disabled]="disabled">
                        <option *ngFor="let tz of zonedDateTimePickerConfiguration.supportedTimeZones" [value]="tz.timeZone">{{tz.text}}</option>
                    </select>
                </cds-select>
            </cds-input-group>
        </div> 
    `
})
export class ZonedDatePickerComponent implements OnInit {

    /**
     * cds-date needs a string to bind to.
     */
    dateString: string | null = null;

    /**
     * cds-time needs a string to bind to.
     */
    timeString: string | null = null;

    /**
     * cds-select needs a string to bind to.
     */
    timeZone: string | null = null;

    /**
     * The Configuration for the component, e.g. labels or default timezone.
     */
    @Input()
    zonedDateTimePickerConfiguration: ZonedDatePickerConfiguration = new DefaultZonedDatePickerConfiguration();

    /**
     * Sets an initial ``ZonedDateTime`` when initializing the component.
     */
    @Input()
    zonedDateTime: Temporal.ZonedDateTime | string | null = null;

    /**
     * Enables / Disables all controls.
     */
    @Input()
    disabled: boolean = false;

    /**
     * Emits, when a new ``ZoneDateTime`` is calculated by the component.
     */
    @Output()
    zonedDateTimeChange: EventEmitter<Temporal.ZonedDateTime> = new EventEmitter();

    /**
     * Creates a new ``ZonedDateComponent`` and sets the default timezone.
     */
    constructor() {
        this.timeZone = this.zonedDateTimePickerConfiguration.defaultTimeZone;
    }

    ngOnInit(): void {
        
        if (this.zonedDateTime != null) {
            // First convert into a Zoned Date Time ...
            const zonedDateTime = Temporal.ZonedDateTime.from(this.zonedDateTime);

            // ... then extract the Plain Date and Plain Time ...
            this.dateString = zonedDateTime.toPlainDate().toString();
            this.timeString = zonedDateTime.toPlainTime().toString({ smallestUnit: 'minute'});
            
            // ... and finally set the TimeZone in a safe way.
            this.setZonedDateTimeSafe(zonedDateTime);
        }
    }

    /**
     * Sets the ``ZonedDateTime`` of the component in a safe way, which means: If the default Timezone is 
     * not available, we will throw. If the provided timezone in the ``ZonedDateTime`` is not supported, 
     * we will recalculate to the default timezone and emit the change.
     * 
     * @param zonedDateTime - ZonedDateTime to set
     * @returns -
     */
    setZonedDateTimeSafe(zonedDateTime: Temporal.ZonedDateTime) {

        // Make sure we operate on a valid default TimeZone ...
        if(!isTimeZoneSupported(this.zonedDateTimePickerConfiguration.supportedTimeZones, this.zonedDateTimePickerConfiguration.defaultTimeZone)) {
            throw new Error(`The default TimeZone '${this.zonedDateTimePickerConfiguration.defaultTimeZone}' is not supported.`)
        }

        const timeZone = zonedDateTime.timeZone;

        if (!timeZone) {
            this.timeZone = this.zonedDateTimePickerConfiguration.defaultTimeZone;
            return;
        }

        // There are no complex TimeZone Mapping involved in the Picker. So if the TimeZone is not supported, 
        // we just recalculate the given ZonedDateTime to the default TimeZone:
        if (!timeZone.id || !isTimeZoneSupported(this.zonedDateTimePickerConfiguration.supportedTimeZones, timeZone.id)) {

            this.timeZone = this.zonedDateTimePickerConfiguration.defaultTimeZone;
            this.zonedDateTime = zonedDateTime.withTimeZone(this.zonedDateTimePickerConfiguration.defaultTimeZone);

            this.zonedDateTimeChange.emit(this.zonedDateTime);

            return;
        }

        // At the point we are safe to set the TimeZone:
        this.timeZone = timeZone.id;
    }

    /**
     * Emits when the user selected a new date.
     * 
     * @param event - Change Event
     */
    onDateChange(event: any) {
        this.dateString = event.target.value;
        this.setDateTime();
    }

    /**
     * Emits when the user selected a new time.
     * 
     * @param event - Change Event
     */
    onTimeChange(event: any) {
        this.timeString = event.target.value;
        this.setDateTime();
    }

    /**
     * Emits when the user selected a new Timezone.
     * 
     * @param event - Change Event
     */
    onTimeZoneChange(event: any) {
        this.timeZone = event.target.value;
        this.setDateTime();
    }

    /**
     * Sets and emits new ``ZonedDateTime``, but only if the user provided a valid date, time and timezone.
     */
    setDateTime() {

        if (this.isValidDateString(this.dateString) && this.isValidTimeString(this.timeString) && this.timeZone != null) {

            const zonedDateTime = Temporal.PlainDateTime.from(this.dateString!)
                .withPlainTime(this.timeString!)
                .toZonedDateTime(this.timeZone);

            this.zonedDateTimeChange.emit(zonedDateTime);
        }
    }

    /**
     * Checks if a value is a valid date string, such as "2020-11-01".
     * 
     * @param value - Date String
     * @returns ``true`` if the value is a valid date string
     */
    isValidDateString(value: string | null): boolean {
        if(value == null) {
            return false;
        }

        try {
            Temporal.PlainDate.from(value);
            return true;
        } catch {
            return false;
        }
    }

    /**
     * Checks if a value is a valid time string, such as "19:30".
     * 
     * @param value - Time String
     * @returns ``true`` if the value is a time date string
     */
    isValidTimeString(value: string | null) {
        if(value == null) {
            return false;
        }

        try {
            Temporal.PlainTime.from(value);
            return true;
        } catch {
            return false;
        }
    }
}