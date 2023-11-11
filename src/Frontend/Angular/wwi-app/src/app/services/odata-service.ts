// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable, tap } from "rxjs";
import { ODataBatchRequest } from "../models/odata-batch";
import { IODataBatchResponse, IODataEntitiesResponse, IODataEntityResponse, ODataBatchResponse, ODataEntitiesResponse, ODataEntityResponse } from "../models/odata-response";

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
    getEntity<T>(url: string): Observable<IODataEntityResponse<T>> {
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
    getEntities<T>(url: string): Observable<IODataEntitiesResponse<T>> {
        return this.httpClient
            .get<any>(url, { observe: 'response' })
            .pipe(map(response => new ODataEntitiesResponse<T>(response)));
    }

    /**
     * Invokes the PATCH Endpoint to update an entity. We are setting the 
     * Prefer Header to "return=representation", so we get the full updated 
     * object in return.
     *
     * @typeParam T - Type of the entity
     * @param url - URL for an OData-enabled enpoint
     * @returns Response containing metadata and entities
     */
    executeUpdate<T>(url: string, entity: T): Observable<IODataEntityResponse<T>> {
        
        let headers = new HttpHeaders({
            "Content-Type": "application/json;odata.metadata=minimal;odata.streaming=true;IEEE754Compatible=false;",
            "Prefer": "return=representation"
        });

        return this.httpClient
            .patch<any>(url, JSON.stringify(entity), {
                headers: headers,
                observe: 'response' })
            .pipe(map(response => new ODataEntityResponse<T>(response)));
    }

    /**
     * Executes a Batch request to an OData-enabled $batch enpoint.
     *
     * @param url - Batch URL, which usually ends with $batch
     * @returns Response containing the results of all batched requests.
     */
    executeBatch(url: string, requests: ODataBatchRequest[]): Observable<ODataBatchResponse> {
        
        let headers = new HttpHeaders({
            "Content-Type": "application/json;odata.metadata=minimal;odata.streaming=true;IEEE754Compatible=false;",
            "Prefer": "return=representation"
        });

        return this.httpClient
            .post<any>(url, { "requests" : requests }, { headers: headers, observe: 'response' })
            .pipe(map(response => new ODataBatchResponse(response)));
    }
}