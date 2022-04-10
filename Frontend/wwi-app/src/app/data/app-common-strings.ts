// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AppTimeZone } from "../models/timezone";
import { appTimeZones } from "./app-timezones";

/**
 * All Resource strings available in the application.
 */
export interface AppCommonStrings {
    core: {
        dateTimePicker: {
            labelDate: string,
            labelTime: string,
            labelTimeZone: string,
        },
        datagrid: {
            pagination: {
                items: string,
                of: string,
                items_per_page: string,
            }
        }
    },
    timeZone: string,
    timeZones: AppTimeZone[],
    filters: {
        operator: string,
        applyFilter: string,
        resetFilter: string,
        numericFilter: {
            placeholder: string,
            labelOperator: string,
            labelValue: string,
            labelLow: string,
            labelHigh: string,
        }
        stringFilter: {
            placeholder: string,
            labelOperator: string,
        },
        booleanFilter: {
            labelOperator: string,
        },
        dateFilter: {
            labelDate: string,
            labelFrom: string,
            labelTo: string,
            screenreader: string,
            placeholderFrom: string,
            placeholderTo: string,
        }
    },
    filterOperators : {
        none: string,
        before: string,
        after: string,
        isEqualTo: string,
        isNotEqualTo: string,
        contains: string,
        notContains: string,
        startsWith: string,
        endsWith: string,
        isNull: string,
        isNotNull: string,
        isEmpty: string,
        isNotEmpty: string,
        isGreaterThanOrEqualTo: string,
        isGreaterThan: string,
        isLessThanOrEqualTo: string,
        isLessThan: string,
        betweenInclusive: string,
        betweenExclusive: string,
        all: string,
        yes: string,
        no: string,
    },
    tables: {
        cities: {
            cityId: string,
            cityName: string,
            stateProvince: string,
            latestRecordedPopulation: string,
            lastEditedBy: string,
        },
        coldRoomTemperatures: {
            coldRoomTemperatureId: string,
            coldRoomSensorNumber: string,
            recordedWhen: string,
            temperature: string,
        },
        colors: {
            colorId: string,
            colorName: string,
            lastEditedBy: string,
        },
        countries:  {
            countryId: string,
            countryName: string,
            formalName: string,
            isoAlpha3Code: string,
            isoNumericCode: string,
            countryType: string,
            latestRecordedPopulation: string,
            continent: string,
            region: string,
            subregion: string,
            lastEditedBy: string,
        },
        customers: {
            customerId: string,
            customerName: string,
            phoneNumber?: string,
            faxNumber?: string,
            deliveryAddressLine1?: string,
            deliveryAddressLine2?: string | undefined,
            deliveryPostalCode?: string,
            postalAddressLine1?: string,
            postalAddressLine2?: string | undefined,
            postalPostalCode?: string,
            lastEditedBy: string,
        }
    },
    sidemenu: {
        home: string,
        tables: string,
        cities: string,
        countries: string,
        customers: string,
    },
    header: {
        title: string,
        navigation: {
            customers: string,
        }
    },
    dropdown: {
        title: string,
        profile: string,
    }
};

export const defaultCommonStrings: AppCommonStrings = {
    core: { 
        dateTimePicker: {
            labelDate: 'Date',
            labelTime: 'Time',
            labelTimeZone: 'Timezone'
        },
        datagrid: {
            pagination: {
                of: "of",
                items: "items",
                items_per_page: "items per page"
            }
        }
    },
    timeZone: 'Europe/Berlin',
    timeZones: appTimeZones,
    filters: {
        operator: "Operator",
        applyFilter: "Apply",
        resetFilter: "Reset",
        booleanFilter: {
            labelOperator: "Show Values"
        },
        dateFilter: {
            labelFrom: "From",
            labelTo: "To",
            labelDate: "Date",
            placeholderFrom: "Select a Start Date ...",
            placeholderTo: "Select an End Date",
            screenreader: "In this Filter you can filter for a Date Range and Tab Throught the Controls. Use Apply to apply the filter",
        },
        numericFilter:  {
            labelOperator: "Operator",
            labelValue: "Value",
            labelLow: "Low",
            labelHigh: "High",
            placeholder: "Select a Value ...",
        },
        stringFilter: {
            labelOperator: "Operator",
            placeholder: "Enter your Search Text ..."
        }
    },
    filterOperators: {
        none: "None",
        after: "After",
        before: "Before",
        betweenInclusive: "Between",
        betweenExclusive: "Between (Exclusive)",
        contains: "Contains",
        endsWith: "Ends with",
        isEmpty: "Is Empty",
        isEqualTo: "Is equal to",
        isGreaterThan: "Is greater than",
        isGreaterThanOrEqualTo: "Ist greater than or equal to",
        isLessThan: "Is less than",
        isLessThanOrEqualTo: "Is less than or equal to",
        isNotEmpty: "Is not empty",
        isNotEqualTo: "Is not equal to",
        isNotNull: "Is not null",
        isNull: "Is null",
        no: "No",
        yes: "Yes",
        notContains: "Not contains",
        startsWith: "Starts with",
        all: "All"
    },
    tables: {
        cities: {
            cityId: "Id",
            cityName: "Name",
            stateProvince: "State / Province",
            latestRecordedPopulation: "Population",
            lastEditedBy: "Last Edited By"
        },
        coldRoomTemperatures: {
            coldRoomTemperatureId: "Id",
            coldRoomSensorNumber: "Sensor #",
            recordedWhen: "Recorded when",
            temperature: "Temperature"
        },
        colors: {
            colorId: "Id",
            colorName: "Name",
            lastEditedBy: "Last Edited By"
        },
        countries: {
            countryId: "Id",
            continent: "Continent",
            countryName: "Name",
            countryType: "Type",
            formalName: "Formal Name",
            isoAlpha3Code: "Iso Code",
            isoNumericCode: "Iso Numeric Code",
            lastEditedBy: "Last Edited By",
            latestRecordedPopulation: "Population",
            region: "Region",
            subregion: "Subregion",
        },
        customers: {
            customerId: "Id",
            customerName: "Name",
            postalAddressLine1: "Postal 1",
            postalAddressLine2: "Postal 2",
            postalPostalCode: "Postal Code",
            deliveryAddressLine1: "Delivery 1",
            deliveryAddressLine2: "Delivery 2",
            deliveryPostalCode: "Delivery Postal Code",
            phoneNumber: "Phone Number",
            faxNumber: "Fax Number",
            lastEditedBy: "Last Edited By"
        }
    },
    header: {
        title: "Wide World Importers",
        navigation: {
            customers: "Customers"
        }
    },
    // Side Menu:
    sidemenu: {
        home: "Home",
        tables: "Tables",
        cities: "Cities",
        countries: "Countries",
        customers: "Customers",
    },
    // Dropdown Menu:
    dropdown: {
        title: "Settings",
        profile: "Profile"
    }
};

export const germanCommonStrings: AppCommonStrings = {
    core: {
        dateTimePicker: {
            labelDate: "Datum",
            labelTime: "Zeit",
            labelTimeZone: 'Zeitzone'
        },
        datagrid : {
            pagination: {
                items: "Elemente",
                of: "von",
                items_per_page: "elemente pro Seite"
            }
        }
    },
    timeZone: "Europe/Berlin",
    timeZones: appTimeZones,
    filters: {
        operator: "Operator",
        applyFilter: "Anwenden",
        resetFilter: "Zurücksetzen",
        booleanFilter: {
            labelOperator: "Zeige Werte an"
        },
        dateFilter: {
            labelFrom: "Von",
            labelTo: "Bis",
            labelDate: "Datum",
            placeholderFrom: "Wählen Sie ein Start-Datum ein ...",
            placeholderTo: "Wählen Sie ein End-Datum ein ...",
            screenreader: "In diesem Filter kann nach einem Datums-Bereich gefiltert werden",
        },
        numericFilter:  {
            labelOperator: "Operator",
            labelValue: "Wert",
            labelLow: "Untere Grenze",
            labelHigh: "Obere Grenze",
            placeholder: "Geben Sie einen Wert ein ...",
        },
        stringFilter: {
            labelOperator: "Operator",
            placeholder: "Geben Sie einen Text ein ..."
        }
    },
    filterOperators: {
        none: "Kein Filter",
        after: "Nach",
        before: "Vor",
        betweenInclusive: "Zwischen",
        betweenExclusive: "Zwischen (Exklsuiv)",
        contains: "Enthält",
        endsWith: "Endet mit",
        isEmpty: "Ist leer",
        isEqualTo: "Ist gleich",
        isGreaterThan: "Ist größer als",
        isGreaterThanOrEqualTo: "Ist größer gleich",
        isLessThan: "Ist kleiner als",
        isLessThanOrEqualTo: "Ist kleiner gleich",
        isNotEmpty: "Ist nicht leer",
        isNotEqualTo: "Ist ungleich",
        isNotNull: "Ist nicht null",
        isNull: "Ist null",
        no: "Nein",
        yes: "Ja",
        notContains: "Beinhaltet nicht",
        startsWith: "Beginnt mit",
        all: "Alle",
    },
    tables: {
        cities: {
            cityId: "Id",
            cityName: "Name",
            stateProvince: "Bundesland / Provinz",
            latestRecordedPopulation: "Einwohner",
            lastEditedBy: "Letzter Bearbeiter"
        },
        coldRoomTemperatures: {
            coldRoomTemperatureId: "Id",
            coldRoomSensorNumber: "Sensor #",
            recordedWhen: "Aufnahmezeitpunkt",
            temperature: "Temperatur"
        },
        colors: {
            colorId: "Id",
            colorName: "Name",
            lastEditedBy: "Letzter Bearbeiter"
        },
        countries: {
            countryId: "Id",
            countryName: "Name",
            formalName: "Formaler Name",
            countryType: "Typ",
            continent: "Kontinent",            
            isoAlpha3Code: "Iso Code",
            isoNumericCode: "Numerischer Iso Code",
            latestRecordedPopulation: "Einwohner",
            region: "Region",
            subregion: "Unter-Region",
            lastEditedBy: "Letzter Bearbeiter",
        },
        customers: {
            customerId: "Id",
            customerName: "Name",
            postalAddressLine1: "Postalisch 1",
            postalAddressLine2: "Postalisch 2",
            postalPostalCode: "PLZ",
            deliveryAddressLine1: "Lieferaddresse 1",
            deliveryAddressLine2: "Lieferaddresse 2",
            deliveryPostalCode: "Lieferaddresse PLZ",
            phoneNumber: "Telefonnummer",
            faxNumber: "Faxnummer",
            lastEditedBy: "Letzter Bearbeiter"
        }
    },
    sidemenu: {
        home: "Home",
        tables: "Stammdaten",
        cities: "Städte",
        countries: "Länder",
        customers: "Kunden",
    },
    header: {
        title: "WWI",
        navigation: {
            customers: "Kunden",
        }
    },
    dropdown: {
        title: "Einstellungen",
        profile: "Profil",
    }
};