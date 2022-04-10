// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { dropDownItems as dropDownMenuItems, headerMenuItems, sidebarMenuItems } from "../data/app-menu-items";
import { MenuItem } from "../models/menu-item";
import { TranslationService } from "./translation.service";

/**
 * Provides all Menu-related functionality.
 */
@Injectable({
    providedIn: `root`
})
export class MenuService {

    /**
     * CTOR
     * 
     * @param translationService - Translations to apply.
     */
    constructor(private translationService: TranslationService) { }

    /**
     * Generates an ``Observable<MenuItem>`` for the page header.
     * 
     * @returns An ``Observable<MenuItem>`` with the available items.
     */
    public header(): Observable<MenuItem[]> {
        const menuItems = headerMenuItems(this.translationService);
        
        return of<MenuItem[]>(menuItems);
    }

    /**
     * Generates an ``Observable<MenuItem>`` for the page header dropdown.
     * 
     * @returns An ``Observable<MenuItem>`` with the available items.
     */
     public dropdown(): Observable<MenuItem[]> {

        const menuItems: Array<MenuItem> =  dropDownMenuItems(this.translationService);
        
        return of<MenuItem[]>(menuItems);
    }

    /**
     * Generates an ``Observable<MenuItem>`` for the side bar.
     * 
     * @returns An ``Observable<MenuItem>`` with the available items.
     */
     public sidenav(): Observable<MenuItem[]> {
        
        const menuItems = sidebarMenuItems(this.translationService);

        return of<MenuItem[]>(menuItems);
    }
}