// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Inject, Injectable, LOCALE_ID } from "@angular/core";
import { ClrCommonStrings, ClrCommonStringsService, commonStringsDefault } from "@clr/angular";
import { germanLocale } from "../data/clr-common-strings";

/**
 * The ``CommonStringService`` is used to initialize the Clarity ``ClrCommonStringsService`` with the 
 * values of a given Locale, which is injected by Angulars Dependency Injection framework as a Injection 
 * Token.
 * 
 * @public
 */
@Injectable({
    providedIn: `root`
})
export class CommonStringsService {

    /**
     * The available Clarity component translations.
     */
    translations: Map<string, ClrCommonStrings> = new Map([
        ['en', commonStringsDefault],
        ['de', germanLocale],
    ]);

    /**
     * Initializes the ``CommonStringsService``.
     * 
     * @param locale - Application locale
     * @param clrCommonStringsService - Clarity ``ClrCommonStringsService`` for control translations
     */
    constructor(@Inject(LOCALE_ID) locale: string, private clrCommonStringsService: ClrCommonStringsService) {
        this.set(locale);
    }

    /**
     * Sets the Locale and updates the wrapped ``ClrCommonStringsService``.
     * 
     * @param locale - Application locale
     */
    public set(locale: string) {
        this.clrCommonStringsService.localize(this.get(locale));
    }

    /**
     * Gets the ``ClrCommonStrings`` for a given locale.
     * 
     * @param locale - Application Locale
     * @returns The ``ClrCommonStrings`` for a given locale
     */
    private get(locale: string): ClrCommonStrings {
        return this.translations.has(locale) ? this.translations.get(locale)! : commonStringsDefault;
    }
}