import {ValueObject} from 'immutable';
import {ArraysModel} from '../../../../shared/models/arrays.model';


export class Category implements ValueObject {
    readonly id: number;
    readonly label: string;
    readonly description: string;

    constructor(builder: CategoryBuilder) {
        this.id = builder.id;
        this.label = builder.label;
        this.description = builder.description;
    }

    static newBuilder(): CategoryBuilder {
        return new CategoryBuilder();
    }

    static copy(category: Category): CategoryBuilder {
        return this.newBuilder()
            .withId(category.id)
            .withLabel(category.label)
            .withDescription(category.description);
    }

    static fromJson(json: object): Category {
        return this.newBuilder()
            .withId(json['id'])
            .withLabel(json['label'])
            .withDescription(json['description'])
            .build();
    }

    equals(category: Category): boolean {
        return this.id === category.id;
    }

    hashCode(): number {
        return ArraysModel.hashCode(this.id);
    }
}

class CategoryBuilder {
    id: number;
    label: string;
    description: string;

    constructor() {
        this.label = '';
    }

    withId(id: number): CategoryBuilder {
        this.id = id;
        return this;
    }

    withLabel(label: string): CategoryBuilder {
        this.label = label;
        return this;
    }
    withDescription(description: string): CategoryBuilder {
        this.description = description;
        return this;
    }

    build(): Category {
        return new Category(this);
    }
}
