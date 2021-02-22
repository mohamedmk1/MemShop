import {Action} from '@ngrx/store';
import {Category} from '../../models/category.model';
import {List} from 'immutable';

export enum CategoryManagementActionTypes {
    LoadCategories = '[CategoryManagement] Load all categories',
    LoadCategoriesSuccess = '[CategoryManagement] Load all categories success',
    LoadCategoriesFailure = '[CategoryManagement] Load all categories failure',

    LoadCategoryById = '[CategoryManagement] Load category by id',
    LoadCategoryByIdSuccess = '[CategoryManagement] Load category by id success',
    LoadCategoryByIdFailure = '[CategoryManagement] Load category by id failure',

    CreateCategory = '[CategoryManagement] Create category',
    CreateCategorySuccess = '[CategoryManagement] Create category success',
    CreateCategoryFailure = '[CategoryManagement] Create category failure',

    UpdateCategory = '[CategoryManagement] Update category',
    UpdateCategorySuccess = '[CategoryManagement] Update category success',
    UpdateCategoryFailure = '[CategoryManagement] Update category failure',

    DeleteCategory = '[CategoryManagement] Delete category',
    DeleteCategorySuccess = '[CategoryManagement] Delete category success',
    DeleteCategoryFailure = '[CategoryManagement] Delete category failure'
}

export class LoadCategories implements Action {
    readonly type = CategoryManagementActionTypes.LoadCategories;
    constructor(public payload: any) {}
}

export class LoadCategoriesSuccess implements Action {
    readonly type = CategoryManagementActionTypes.LoadCategoriesSuccess;
    constructor(public payload: List<Category>) {}
}

export class LoadCategoriesFailure implements Action {
    readonly type = CategoryManagementActionTypes.LoadCategoriesFailure;
    constructor(public payload: string) {}
}

export class LoadCategoryById implements Action {
    readonly type = CategoryManagementActionTypes.LoadCategoryById;
    constructor(public payload: number) {}
}

export class LoadCategoryByIdSuccess implements Action {
    readonly type = CategoryManagementActionTypes.LoadCategoryByIdSuccess;
    constructor(public payload: Category) {}
}

export class LoadCategoryByIdFailure implements Action {
    readonly type = CategoryManagementActionTypes.LoadCategoryByIdFailure;
    constructor(public payload: string) {}
}

export class CreateCategory implements Action {
    readonly type = CategoryManagementActionTypes.CreateCategory;
    constructor(public payload: Category) {}
}

export class CreateCategorySuccess implements Action {
    readonly type = CategoryManagementActionTypes.CreateCategorySuccess;
    constructor(public payload: Category) {}
}

export class CreateCategoryFailure implements Action {
    readonly type = CategoryManagementActionTypes.CreateCategoryFailure;
    constructor(public payload: string) {}
}

export class UpdateCategory implements Action {
    readonly type = CategoryManagementActionTypes.UpdateCategory;
    constructor(public payload: Category) {}
}

export class UpdateCategorySuccess implements Action {
    readonly type = CategoryManagementActionTypes.UpdateCategorySuccess;
    constructor(public payload: any) {}
}

export class UpdateCategoryFailure implements Action {
    readonly type = CategoryManagementActionTypes.UpdateCategoryFailure;
    constructor(public payload: string) {}
}

export class DeleteCategory implements Action {
    readonly type = CategoryManagementActionTypes.DeleteCategory;
    constructor(public payload: number) {}
}

export class DeleteCategorySuccess implements Action {
    readonly type = CategoryManagementActionTypes.DeleteCategorySuccess;
    constructor(public payload: any) {}
}

export class DeleteCategoryFailure implements Action {
    readonly type = CategoryManagementActionTypes.DeleteCategoryFailure;
    constructor(public payload: string) {}
}

export type CategoryManagementUnions =
    | LoadCategories
    | LoadCategoriesSuccess
    | LoadCategoriesFailure
    | LoadCategoryById
    | LoadCategoryByIdSuccess
    | LoadCategoryByIdFailure
    | CreateCategory
    | CreateCategorySuccess
    | CreateCategoryFailure
    | UpdateCategory
    | UpdateCategorySuccess
    | UpdateCategoryFailure
    | DeleteCategory
    | DeleteCategorySuccess
    | DeleteCategoryFailure;
