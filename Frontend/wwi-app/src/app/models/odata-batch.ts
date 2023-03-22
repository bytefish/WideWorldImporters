// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { ODataEntitiesResponse } from "./odata-response";

export interface ODataBatchRequest {

    /**
     * Correlation ID.
     */
    id: string;

    /**
     * HTTP method to use.
     */
    method: "GET" | "PATCH" | "POST" | "PUT" | "DELETE";

    /**
     * OData URL.
     */
    url: string;
}

export interface ODataBatchResponse {

    /**
     * Correlation ID.
     */
    id: string;

    /**
     * HTTP Status.
     */
    status: number;

    /**
     * Headers.
     */
    headers: Array<[string, string | null]>;

    /**
     * Headers.
     */
    body: any;
}