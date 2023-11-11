// Licensed under the MIT license. See LICENSE file in the project root for full license information.

export type ODataBatchMethod = "GET" | "PATCH" | "POST" | "PUT" | "DELETE";

export interface ODataBatchRequest {

    /**
     * Correlation ID.
     */
    id: string;

    /**
     * HTTP method to use.
     */
    method: ODataBatchMethod;

    /**
     * OData URL.
     */
    url: string;

    /**
     * Optional Body to send for POST / PUT / PATCH.
     */
    body?: any;

    /**
     * Optional atomicity group name.
     */
    atomicityGroup?: string;

    /**
     *  
     */
    dependsOn?: string[];
}
