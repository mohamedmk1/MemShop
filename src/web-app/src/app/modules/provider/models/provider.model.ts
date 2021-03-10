import {ValueObject} from 'immutable';
import {ArraysModel} from '../../../shared/models/arrays.model';

export class ProviderModel implements ValueObject {
    readonly id: number;
    readonly name: string;
    readonly address: string;
    readonly zipCode: string;
    readonly country: string;

    constructor(builder: ProviderBuilder) {
        this.id = builder.id;
        this.name = builder.name;
        this.address = builder.address;
        this.zipCode = builder.zipCode;
        this.country = builder.country;
    }

    static newBuilder(): ProviderBuilder {
        return new ProviderBuilder();
    }

    static copy(provider: ProviderModel): ProviderBuilder {
        return this.newBuilder()
            .withId(provider.id)
            .withName(provider.name)
            .withAddress(provider.address)
            .withZipCode(provider.zipCode)
            .withCountry(provider.country);
    }

    static fromJson(json: any): ProviderModel {
        return this.newBuilder()
            .withId(json['id'])
            .withName(json['name'])
            .withAddress(json['address'])
            .withZipCode(json['zipCode'])
            .withCountry(json['country'])
            .build();
    }

    equals(provider: ProviderModel): boolean {
        return this.id === provider.id;
    }

    hashCode(): number {
        return ArraysModel.hashCode(this.id);
    }
}

export class ProviderBuilder {
    id: number;
    name: string;
    address: string;
    zipCode: string;
    country: string;

    constructor() {
        this.name = '';
        this.address = '';
        this.zipCode = '';
        this.country = '';
    }

    withId(id: number): ProviderBuilder {
        this.id = id;
        return this;
    }

    withName(name: string): ProviderBuilder {
        this.name = name;
        return this;
    }

    withAddress(address: string): ProviderBuilder {
        this.address = address;
        return this;
    }

    withZipCode(zipCode: string): ProviderBuilder {
        this.zipCode = zipCode;
        return this;
    }

    withCountry(country: string): ProviderBuilder {
        this.country = country;
        return this;
    }

    build(): ProviderModel {
        return new ProviderModel(this);
    }
}
