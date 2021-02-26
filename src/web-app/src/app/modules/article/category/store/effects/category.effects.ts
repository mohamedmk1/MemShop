import {Injectable} from '@angular/core';
import {CategoryService} from '../../services/category.service';
import {act, Actions, createEffect, Effect, ofType} from '@ngrx/effects';
import {
    addCategory,
    addCategoryFailed,
    addCategorySuccess, deleteCategory, deleteCategoryFailed, deleteCategorySuccess,
    loadCategories,
    loadCategoriesFailed,
    loadCategoriesSuccess,
    loadCategoryById,
    loadCategoryByIdFailed,
    loadCategoryByIdSuccess,
    updateCategory,
    updateCategoryFailed,
    updateCategorySuccess
} from '../actions/category.actions';
import {catchError, map, switchMap} from 'rxjs/operators';
import {of} from 'rxjs';


@Injectable()
export class CategoryEffects {
    constructor(
        private readonly actions$: Actions,
        private readonly categoryService: CategoryService
    ) {}

    onLoadCategories$ = createEffect(() =>
        this.actions$.pipe(
            ofType(loadCategories),
            switchMap(() =>
                this.categoryService.getCategories().pipe(
                    map((categories) => loadCategoriesSuccess({ categories })),
                    catchError((errorResponse) => of(loadCategoriesFailed({ errorResponse })))
                )
            )
        )
    );

    onLoadCategoryById$ = createEffect(() =>
        this.actions$.pipe(
            ofType(loadCategoryById),
            switchMap((action) =>
                this.categoryService.getCategoryById(action.categoryId).pipe(
                    map((category) => loadCategoryByIdSuccess({ category })),
                    catchError((errorResponse) => of(loadCategoryByIdFailed({ errorResponse })))
                )
            )
        )
    );

    onAddCategory$ = createEffect(() =>
        this.actions$.pipe(
            ofType(addCategory),
            switchMap((action) =>
                this.categoryService.createCategory(action.category).pipe(
                    map((category) => addCategorySuccess({ category })),
                    catchError((errorResponse) => of(addCategoryFailed({ errorResponse })))
                )
            )
        )
    );

    onUpdateCategory$ = createEffect(() =>
        this.actions$.pipe(
            ofType(updateCategory),
            switchMap((action) =>
                this.categoryService.updateCategory(action.category).pipe(
                    map((category) => updateCategorySuccess({ category })),
                    catchError((errorResponse) => of(updateCategoryFailed(errorResponse)))
                )
            )
        )
    );

    onDeleteCategory$ = createEffect(() =>
        this.actions$.pipe(
            ofType(deleteCategory),
            switchMap((action) =>
                this.categoryService.deleteCategory(action.id).pipe(
                    map(() => deleteCategorySuccess({id: action.id})),
                    catchError((errorResponse) => of(deleteCategoryFailed(errorResponse)))
                )
            )
        )
    );
}
