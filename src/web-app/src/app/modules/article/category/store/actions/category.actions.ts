import {createAction, props} from '@ngrx/store';
import {Category} from '../../models/category.model';
import {List} from 'immutable';
import {HttpErrorResponse} from '@angular/common/http';
import {Update} from '@ngrx/entity';

export const loadCategories = createAction('[CategoryManagement] Load categories');

export const loadCategoriesSuccess = createAction(
    '[CategoryManagement] Load categories SUCCESS',
    props< { categories: List<Category> }>()
);

export const loadCategoriesFailed = createAction(
    '[CategoryManagement] Load categories FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const loadCategoryById = createAction(
    '[CategoryManagement] Load category by id',
    props<{ categoryId: number }>()
);

export const loadCategoryByIdSuccess = createAction(
    '[CategoryManagement] Load category by id SUCCESS',
    props<{ category: Category }>()
);

export const loadCategoryByIdFailed = createAction(
    '[CategoryManagement] Load category by id FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const addCategory = createAction(
    '[CategoryManagement] Add category',
    props<{ category: Category }>()
);

export const addCategorySuccess = createAction(
    '[CategoryManagement] Add category SUCCESS',
    props<{ category: Category }>()
);

export const addCategoryFailed = createAction(
    '[CategoryManagement] Add category FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const updateCategory = createAction(
    '[CategoryManagement] Update category',
    props<{ category: Category}>()
);

export const updateCategorySuccess = createAction(
    '[CategoryManagement] Update category SUCCESS',
    props<{ category: Category}>()
);

export const updateCategoryFailed = createAction(
    '[CategoryManagement] Update category FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const deleteCategory = createAction(
    '[CategoryManagement] Delete category',
    props<{ id: number}>()
);

export const deleteCategorySuccess = createAction(
    '[CategoryManagement] Delete category SUCCESS',
    props<{ id: number}>()
);

export const deleteCategoryFailed = createAction(
    '[CategoryManagement] Delete category FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const clearCategories = createAction('[CategoryManagement] Clear categories');

export const clearSelectedCategory = createAction('[CategoryManagement] Clear selected category');
