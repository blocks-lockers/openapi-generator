/* tslint:disable */
/* eslint-disable */
/**
 * OpenAPI Petstore
 * This is a sample server Petstore server. For this sample, you can use the api key `special-key` to test the authorization filters.
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { mapValues } from '../runtime';
import type { Part } from './Part';
import {
    PartFromJSON,
    PartFromJSONTyped,
    PartToJSON,
    PartToJSONTyped,
} from './Part';

/**
 * Contains all the matching parts
 * @export
 * @interface MatchingParts
 */
export interface MatchingParts {
    /**
     * List of all the connected parts
     * @type {Array<Part>}
     * @memberof MatchingParts
     */
    connected: Array<Part>;
    /**
     * List of all the related parts
     * @type {Array<Part>}
     * @memberof MatchingParts
     */
    related: Array<Part>;
}

/**
 * Check if a given object implements the MatchingParts interface.
 */
export function instanceOfMatchingParts(value: object): value is MatchingParts {
    if (!('connected' in value) || value['connected'] === undefined) return false;
    if (!('related' in value) || value['related'] === undefined) return false;
    return true;
}

export function MatchingPartsFromJSON(json: any): MatchingParts {
    return MatchingPartsFromJSONTyped(json, false);
}

export function MatchingPartsFromJSONTyped(json: any, ignoreDiscriminator: boolean): MatchingParts {
    if (json == null) {
        return json;
    }
    return {
        
        'connected': ((json['connected'] as Array<any>).map(PartFromJSON)),
        'related': ((json['related'] as Array<any>).map(PartFromJSON)),
    };
}

  export function MatchingPartsToJSON(json: any): MatchingParts {
      return MatchingPartsToJSONTyped(json, false);
  }

  export function MatchingPartsToJSONTyped(value?: MatchingParts | null, ignoreDiscriminator: boolean = false): any {
    if (value == null) {
        return value;
    }

    return {
        
        'connected': ((value['connected'] as Array<any>).map(PartToJSON)),
        'related': ((value['related'] as Array<any>).map(PartToJSON)),
    };
}

