// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AppIcons } from "./icons";

/**
 * A DropDown Item, that can be used for the Settings Dropdown.
 */
export interface DropdownItem {
    
    /**
     * A unique id.
     */
    id: string;

    /**
     * An Icon, that needs to be part of the ``AppIcons`` enum, 
     * so we can guarantee it's available.
     */
    icon?: AppIcons;

    /**
     * The Name, alas the Text in the UI.
     */
    name: string;

    /**
     * A description, which can be used for a Tooltip.
     */
    description: string;

    /**
     * Accessibility.
     */
    ariaLabel: string;

    /**
     * The Router Url.
     */
    url?: string;
    
    /**
     * For complex Dropdown menus, we can provide optional 
     * children items, so we can nest the menus.
     */
    children?: DropdownItem[];
}