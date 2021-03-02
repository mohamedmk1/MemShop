import {Injectable} from '@angular/core';
import {CategoryService} from '../../services/category.service';
import {Actions, createEffect, ofType} from '@ngrx/effects';
import {
    addCategory,
    addCategoryFailed,
    addCategorySuccess, clearSelectedCategory, deleteCategory, deleteCategoryFailed, deleteCategorySuccess,
    loadCategories,
    loadCategoriesFailed,
    loadCategoriesSuccess,
    loadCategoryById,
    loadCategoryByIdFailed,
    loadCategoryByIdSuccess, setSelectedCategory,
    updateCategory,
    updateCategoryFailed,
    updateCategorySuccess
} from '../actions/category.actions';
import {catchError, map, switchMap, tap} from 'rxjs/operators';
import {of} from 'rxjs';
import {Router} from '@angular/router';


@Injectable()
export class CategoryEffects {
    constructor(
        private readonly actions$: Actions,
        private readonly categoryService: CategoryService,
        private readonly router: Router
    ) {}

    onLoadCategories$ = createEffect(() => this.actions$.pipe(
            ofType(loadCategories),
            switchMap(() =>
                this.categoryService.getCategories().pipe(
                    map(categories => loadCategoriesSuccess({ categories })),
                    catchError((errorResponse) => of(loadCategoriesFailed({ errorResponse })))
                )
            )
        )
    );

    onLoadCategoryById$ = createEffect(() => this.actions$.pipe(
            ofType(loadCategoryById),
            switchMap((action) =>
                this.categoryService.getCategoryById(action.categoryId).pipe(
                    map((category) => loadCategoryByIdSuccess({ category })),
                    catchError((errorResponse) => of(loadCategoryByIdFailed({ errorResponse })))
                )
            )
        )
    );

    onLoadCategoryByIdSuccess$ = createEffect(() => this.actions$.pipe(
        ofType(loadCategoryByIdSuccess),
        switchMap((action) => of(setSelectedCategory({category: action.category})))
    ));

    onLoadCategoriesSuccess$ = createEffect(() => this.actions$.pipe(
        ofType(loadCategoriesSuccess),
        switchMap(() => of(clearSelectedCategory()))
    ));

    onAddCategory$ = createEffect(() => this.actions$.pipe(
            ofType(addCategory),
            switchMap((action) =>
                this.categoryService.createCategory(action.category).pipe(
                    map((category) => addCategorySuccess({ category })),
                    catchError((errorResponse) => of(addCategoryFailed({ errorResponse })))
                )
            )
        )
    );

    onUpdateCategory$ = createEffect(() => this.actions$.pipe(
            ofType(updateCategory),
            switchMap((action) =>
                this.categoryService.updateCategory(action.category).pipe(
                    map((category) => updateCategorySuccess({ category })),
                    catchError((errorResponse) => of(updateCategoryFailed(errorResponse)))
                )
            )
        )
    );

    onDeleteCategory$ = createEffect(() => this.actions$.pipe(
            ofType(deleteCategory),
            switchMap((action) =>
                this.categoryService.deleteCategory(action.id).pipe(
                    map(() => deleteCategorySuccess({id: action.id})),
                    catchError((errorResponse) => of(deleteCategoryFailed(errorResponse)))
                )
            )
        )
    );

    onCategoryEditAddSuccess$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(addCategorySuccess, updateCategorySuccess),
                tap(() => this.router.navigate(['/category/list']))
            ),
        { dispatch: false }
    );
}
