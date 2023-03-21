// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { ODataError } from "./odata-error";

/**
* Response for all OData errors, see http://docs.oasis-open.org/odata/odata-json-format/v4.01/odata-json-format-v4.01.html#_Toc38457793. 
* 
* The error response MUST be a single JSON object. This object MUST have a single name/value pair named error. The value must be an OData error object.
*/
export interface ODataErrorResponse {

    /**
     * The OData Error.
     */
    error: ODataError;
}