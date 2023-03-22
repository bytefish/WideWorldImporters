// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { ODataBatchRequest } from "../models/odata-batch";
import { ODataEntitiesResponse, ODataEntityResponse } from "../models/odata-response";

/**
 * The ``ODataService`` provides functionality to query an OData-enabled 
 * endpoint and parse the HTTP response to a type-safe entity and its 
 * metadata.
 */
@Injectable({
    providedIn: `root`
})
export class ODataService {

    /**
     * Constructs an ``ODataService``.
     * 
     * @param httpClient - The ``HttpClient`` to be used for queries.
     */
    constructor(private httpClient: HttpClient) { }

    /**
     * Queries a OData-enabled enpoint for a single entity of type ``T``. The 
     * response also contains all metadata of the response data.
     *
     * @typeParam T - Type of the entity
     * @param url - URL for an OData-enabled enpoint
     * @returns Response containing metadata and entity
     */
    getEntity<T>(url: string): Observable<ODataEntityResponse<T>> {
        return this.httpClient
            .get<any>(url, { observe: 'response' })
            .pipe(map(response => new ODataEntityResponse<T>(response)));
    }

    /**
     * Queries a OData-enabled enpoint for a entities of type ``T``. The response also 
     * contains all metadata of the response data.
     *
     * @typeParam T - Type of the entity
     * @param url - URL for an OData-enabled enpoint
     * @returns Response containing metadata and entities
     */
    getEntities<T>(url: string): Observable<ODataEntitiesResponse<T>> {
        return this.httpClient
            .get<any>(url, { observe: 'response' })
            .pipe(map(response => new ODataEntitiesResponse<T>(response)));
    }

    /**
     * Sends Batch requests to an OData-enabled $batch enpoint.
     *
     * @typeParam T - Type of the entity
     * @param url - URL for an OData-enabled enpoint
     * @returns Response containing metadata and entities
     */
            getBatch(url: string, requests: ODataBatchRequest[]): Observable<any> {
                return this.httpClient
                    .post<any>(url, {
                        "requests" : requests
                    }, { observe: 'response' });
            }
}