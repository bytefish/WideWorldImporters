// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AppIcons } from "../models/icons";
import { MenuItem } from "../models/menu-item";
import { TranslationService } from "../services/translation.service";

/**
 * Builds the Header menu items.
 * 
 * @param translations - Translations to apply for the Header items.
 * @returns The Header menu items.
 */
 export function dropDownItems(translations: TranslationService): Array<MenuItem> {
    return [
        {
            id: "profile",
            name: translations.keys.dropdown.profile,
            description: translations.keys.dropdown.profile,
            ariaLabel: translations.keys.dropdown.profile,
            url: "/profile"
        },
    ];
};

/**
 * Builds the Header menu items.
 * 
 * @param translations - Translations to apply for the Header items.
 * @returns The Header menu items.
 */
 export function headerMenuItems(translations: TranslationService): Array<MenuItem> {
    return [
        {
            id: "customers",
            name: translations.keys.header.navigation.customers,
            description: translations.keys.header.navigation.customers,
            ariaLabel: translations.keys.header.navigation.customers,
            url: "/tables/customers"
        },
    ];
};

/**
 * Builds the Sidebar menu items.
 * 
 * @param translations - Translations to apply for the Menu Items.
 * @returns The Sidebar menu items.
 */
export function sidebarMenuItems(translations: TranslationService): Array<MenuItem> {
    return [
        {
            id: "home",
            name: translations.keys.sidemenu.home,
            description: translations.keys.sidemenu.home,
            ariaLabel: translations.keys.sidemenu.home,
            icon: AppIcons.Home,
            url: "/home"
        },
        {
            id: 'tables',
            name: translations.keys.sidemenu.tables,
            description: translations.keys.sidemenu.tables,
            ariaLabel: translations.keys.sidemenu.tables,
            icon: AppIcons.Cloud,
            children: [
                {
                    id: "cities",
                    name: translations.keys.sidemenu.cities,
                    description: translations.keys.sidemenu.cities,
                    ariaLabel: translations.keys.sidemenu.cities,
                    icon: AppIcons.Language,
                    url: "/tables/cities"
                },
                {
                    id: "countries",
                    name: translations.keys.sidemenu.countries,
                    description: translations.keys.sidemenu.countries,
                    ariaLabel: translations.keys.sidemenu.countries,
                    icon: AppIcons.Language,
                    url: "/tables/countries"
                },
                {
                    id: "customers",
                    name: translations.keys.sidemenu.customers,
                    description: translations.keys.sidemenu.customers,
                    ariaLabel: translations.keys.sidemenu.customers,
                    icon: AppIcons.Language,
                    url: "/tables/customers"
                },
            ]
        }
    ];
};