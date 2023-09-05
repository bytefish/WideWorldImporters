// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Temporal } from "@js-temporal/polyfill";
import { AppTimeZone } from "../models/timezone";

/**
 * The ZonedDatePickerConfiguration used to configure a ``ZonedDatePicker``.
 */
export interface ZonedDatePickerConfiguration {
    labels: {
        labelDate: string,
        labelTime: string,
        labelTimeZone: string
    },
    defaultTimeZone: string,
    supportedTimeZones: AppTimeZone[],
};

/**
 * Holds the default ZonedDatePicker configuration for the application.
 */
export class DefaultZonedDatePickerConfiguration implements ZonedDatePickerConfiguration {
    labels = { 
        labelDate: "Date",
        labelTime: "Time",
        labelTimeZone: "Timezone"
    };
    defaultTimeZone: string = appTimeZone;
    supportedTimeZones: AppTimeZone[] = appTimeZones;
};

/**
 * The applications default TimeZone.
 */
export const appTimeZone: string = "Europe/Berlin";

/**
 * Contains all supported Timezones of the application.
 */
export const appTimeZones: AppTimeZone[] = [
    { timeZone: "Etc/GMT+12", text: "(UTC-12:00) International Date Line West" },
    { timeZone: "Pacific/Midway", text: "(UTC-11:00) Midway Island, Samoa" },
    { timeZone: "Pacific/Honolulu", text: "(UTC-10:00) Hawaii" },
    { timeZone: "US/Alaska", text: "(UTC-09:00) Alaska" },
    { timeZone: "America/Los_Angeles", text: "(UTC-08:00) Pacific Time (US & Canada)" },
    { timeZone: "US/Arizona", text: "(UTC-07:00) Arizona" },
    { timeZone: "America/Managua", text: "(UTC-06:00) Central America" },
    { timeZone: "US/Central", text: "(UTC-06:00) Central Time (US & Canada)" },
    { timeZone: "America/Bogota", text: "(UTC-05:00) Bogota, Lima, Quito, Rio Branco" },
    { timeZone: "US/Eastern", text: "(UTC-05:00) Eastern Time (US & Canada)" },
    { timeZone: "Canada/Atlantic", text: "(UTC-04:00) Atlantic Time (Canada)" },
    { timeZone: "America/Argentina/Buenos_Aires", text: "(UTC-03:00) Buenos Aires, Georgetown" },
    { timeZone: "America/Noronha", text: "(UTC-02:00) Mid-Atlantic" },
    { timeZone: "Atlantic/Azores", text: "(UTC-01:00) Azores" },
    { timeZone: "Etc/Greenwich", text: "(UTC+00:00) Dublin, Edinburgh, Lisbon, London" },
    { timeZone: "Europe/Berlin", text: "(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna" },
    { timeZone: "Europe/Helsinki", text: "(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius" },
    { timeZone: "Europe/Moscow", text: "(UTC+03:00) Moscow, St. Petersburg, Volgograd" },
    { timeZone: "Asia/Tehran", text: "(UTC+03:30) Tehran" },
    { timeZone: "Asia/Yerevan", text: "(UTC+04:00) Yerevan" },
    { timeZone: "Asia/Kabul", text: "(UTC+04:30) Kabul" },
    { timeZone: "Asia/Yekaterinburg", text: "(UTC+05:00) Yekaterinburg" },
    { timeZone: "Asia/Karachi", text: "(UTC+05:00) Islamabad, Karachi, Tashkent" },
    { timeZone: "Asia/Calcutta", text: "(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi" },
    { timeZone: "Asia/Katmandu", text: "(UTC+05:45) Kathmandu" },
    { timeZone: "Asia/Dhaka", text: "(UTC+06:00) Astana, Dhaka" },
    { timeZone: "Asia/Rangoon", text: "(UTC+06:30) Yangon (Rangoon)" },
    { timeZone: "Asia/Bangkok", text: "(UTC+07:00) Bangkok, Hanoi, Jakarta" },
    { timeZone: "Asia/Hong_Kong", text: "(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi" },
    { timeZone: "Asia/Seoul", text: "(UTC+09:00) Seoul" },
    { timeZone: "Australia/Adelaide", text: "(UTC+09:30) Adelaide" },
    { timeZone: "Australia/Canberra", text: "(UTC+10:00) Canberra, Melbourne, Sydney" },
    { timeZone: "Asia/Magadan", text: "(UTC+11:00) Magadan, Solomon Is., New Caledonia" },
    { timeZone: "Pacific/Auckland", text: "(UTC+12:00) Auckland, Wellington" },
    { timeZone: "Pacific/Tongatapu", text: "(UTC+13:00) Nuku'alofa" },
];

/**
 * Checks if a given timezone can be used in the application.
 * 
 * @param appTimeZones - The Timezones supported by the application
 * @param timeZone - The Timezone to check
 * @returns ``true`` if the timezone can be used.
 */
export function isTimeZoneSupported(appTimeZones: AppTimeZone[], timeZone: string): boolean {

    /**
     * Checks if the Timezone is available in the underlying TzDatabase. This uses 
     * the ``Temporal.TimeZone`` implementation, because if it fails, there is 
     * nothing we can do.
     * 
     * @param timeZone - Timezone Name, e.g. "Europe/Berling"
     * @returns ``true``, if the Timezone is available.
     */
    const isInTzDatabase = (timeZone: string) => {
        try {
            Temporal.TimeZone.from(timeZone);

            return true;
        } catch {
            return false;
        }
    };

    /**
     * Checks if the application supports this Timezone. 
     * 
     * @param timeZone - Timezone Name, e.g. "Europe/Berlin"
     * @returns ``true``, if the Timezone is supported.
     */
    const isInAppTimeZones = (timeZone: string) => {
        return appTimeZones.some(appTimeZone => {
            return appTimeZone.timeZone == timeZone;
        });
    };

    return isInTzDatabase(timeZone) && isInAppTimeZones(timeZone);
}