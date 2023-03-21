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