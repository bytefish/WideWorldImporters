// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * Class representing implementation specific debugging information to help determine the cause of the error.
 */
export interface ODataInnerError {
        
        /**
         * The value for the message name/value pair is a non-empty, language-dependent, human-readable string describing the error. The 
         * Content-Language header MUST contain the language code from [RFC5646] corresponding to the language in which the value for message 
         * is written. It cannot be null.
         */
        message: string;
    
        /**
         * The value for the target name/value pair is a potentially empty string indicating the target of the error (for example, the name 
         * of the property in error). It can be null.
         */
        target?: string;

        /**
         * The value for the target name/value pair is a potentially empty string indicating the target of the error (for example, the name 
         * of the property in error). It can be null.
         */
        stackTrace?: string;

        /**
         * A nested inner error.
         */
        innerError?: ODataInnerError;
}

/**
 * Represents an error detail.
 */
export interface ODataErrorDetail {
    /**
     * The value for the code name/value pair is a non-empty language-independent string. Its value is a service-defined error 
     * code. This code serves as a sub-status for the HTTP error code specified in the response. It cannot be null.
     */
    errorcode: string;
    
    /**
     * The value for the message name/value pair is a non-empty, language-dependent, human-readable string describing the error. The 
     * Content-Language header MUST contain the language code from [RFC5646] corresponding to the language in which the value for message 
     * is written. It cannot be null.
     */
    message: string;

    /**
     * The value for the target name/value pair is a potentially empty string indicating the target of the error (for example, the name 
     * of the property in error). It can be null.
     */
    target?: string;
}

/**
 * Represents an error payload.
 */
export interface ODataError {

    /**
     * The value for the code name/value pair is a non-empty language-independent string. Its value is a service-defined error code. This 
     * code serves as a sub-status for the HTTP error code specified in the response. It cannot be null.
     */
    code: string;

    /**
     * The value for the message name/value pair is a non-empty, language-dependent, human-readable string describing the error. The 
     * Content-Language header MUST contain the language code from [RFC5646] corresponding to the language in which the value for message 
     * is written. It cannot be null.
     */
    message: string;

    /**
     * The value for the target name/value pair is a potentially empty string indicating the target of the error (for example, the name 
     * of the property in error). It can be null.
     */
    target?: string;

    /**
     * The value for the details name/value pair MUST be an array of JSON objects that MUST contain name/value pairs for code and message, 
     * and MAY contain a name/value pair for target.
     */
    details?: ODataErrorDetail[];

    /**
     * The value for the innererror name/value pair MUST be an object. The contents of this object are service-defined. Usually this object 
     * contains information that will help debug the service.
     */
    innerError?: ODataInnerError;
}

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