// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AppIcons } from "./icons";

// A Menu Item:
export interface MenuItem {
    
    /**
     * A unique Id.
     */
    id: string;

    /**
     * Is the Menu Item active?
     */
    active?: boolean;

    /**
     * An Icon, that needs to be part of the ``AppIcons`` enum, 
     * so we can guarantee it's available.
     */
    icon?: AppIcons;

    /**
     * The Name.
     */
    name: string;

    /**
     * The description.
     */
    description: string;

    /**
     * Accessibility.
     */
    ariaLabel: string;

    /**
     * The Router URL.
     */
    url?: string;

    /**
     * The Children.
     */
    children?: MenuItem[];
}