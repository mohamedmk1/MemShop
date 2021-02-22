import {isValueObject, hash} from 'immutable';


export class ArraysModel {
    static hashCode(...values: any[]): number {
        let result = 1;
        values.forEach(value => {
            result = 31 * result + (isValueObject(value) ? value.hashCode() : hash(value));
        });
        return result;
    }
}
