// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * A Timezone defintiion for the application. It contains a Timezone name, such as ``Europe/Berlin`` and 
 * a Text, such as ``(UTC+1) Berlin``.
 */
export interface AppTimeZone {

    /**
     * The Timezone identifier.
     */
    timeZone: string;

    /**
     * A description of the Timezone.
     */
    text: string;
};