// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Inject, Injectable, LOCALE_ID } from "@angular/core";
import { AppCommonStrings, defaultCommonStrings, germanCommonStrings } from "../data/app-common-strings";

/** */
@Injectable({
    providedIn: 'root',
  })
  export class TranslationService {

    /**
     * Holds the Translations available for the application. This could also 
     * be provided using dependency injection.
     */
    translations: Map<string, AppCommonStrings> = new Map([
        [ 'en', defaultCommonStrings ],
        [ 'de', germanCommonStrings ],
    ]);

    /**
     * Constructs a ``TranslationService`` with a given locale.
     * 
     * @param locale - Application locale
     */
    constructor(@Inject(LOCALE_ID) locale: string) {
        this.set(locale);
    }

    /**
     * Sets the translations for the given locale.
     * 
     * @param locale - Locale to use
     */
    public set(locale: string) {
        var translations = this.get(locale);

        this.localize(translations);
    }

    /**
     * Gets the translations for a given locale.
     * 
     * @param locale 
     * @returns 
     */
    private get(locale: string) : AppCommonStrings {
        return this.translations.has(locale) ? this.translations.get(locale)! : defaultCommonStrings;
    }
    
    private _strings = defaultCommonStrings;
  
    /**
     * Allows you to pass in new overrides for localization
     */
    localize(overrides: Partial<AppCommonStrings>) {
      this._strings = { ...this._strings, ...overrides };
    }
  
    /**
     * Access to all of the keys as strings
     */
    get keys(): Readonly<AppCommonStrings> {
      return this._strings;
    }
  
    /**
     * Parse a string with a set of tokens to replace
     */
    parse(source: string, tokens: { [key: string]: string } = {}) {
      const names = Object.keys(tokens);
      let output = source;
      if (names.length) {
        names.forEach(name => {
          output = output.replace(`{${name}}`, tokens[name]);
        });
      }
      return output;
    }
}