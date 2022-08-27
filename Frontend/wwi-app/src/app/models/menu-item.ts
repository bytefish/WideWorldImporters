// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * A menu item in the application, which can be an item in the side-menu, an 
 * item in the header or an item in drop-down.
 */
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
     * An Icon.
     */
    icon?: string | null;

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