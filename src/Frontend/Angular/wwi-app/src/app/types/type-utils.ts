// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * The Angular ``HttpClient`` expects this type as its Query params.
 */
export type HttpQueryParamType = { [param: string]: string | number | boolean | readonly (string | number | boolean)[]; };

