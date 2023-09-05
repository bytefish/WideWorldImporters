// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * Utilities for working with ``string``.
 * @public
 */
export class StringUtils {

    /**
     * Indicates whether a specified string is null, empty, or consists only of white-space characters.
     *
     * @param input - The string to test.
     * @returns ``true`` if the value parameter is ``null`` or Empty, or if value consists exclusively of white-space characters.
     */
    static isNullOrWhitespace(input: string | null): boolean {
        return input == null || !input.trim();
    }
}