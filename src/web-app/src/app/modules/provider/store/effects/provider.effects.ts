import {Injectable} from '@angular/core';
import {Actions, createEffect, ofType} from '@ngrx/effects';
import {Router} from '@angular/router';
import {ProviderService} from '../../services/provider.service';
import {
    addProvider, addProviderFailed, addProviderSuccess, deleteProvider,
    loadProviderById, loadProviderByIdFailed,
    loadProviderByIdSuccess,
    loadProviders,
    loadProvidersFailed,
    loadProvidersSuccess, setSelectedProvider, updateProvider, updateProviderFailed, updateProviderSuccess
} from '../actions/provider.actions';
import {catchError, map, switchMap} from 'rxjs/operators';
import {of} from 'rxjs';
import {
    addCategory, addCategoryFailed, addCategorySuccess, deleteCategory, deleteCategoryFailed, deleteCategorySuccess,
    loadCategoryById,
    loadCategoryByIdFailed,
    loadCategoryByIdSuccess, setSelectedCategory, updateCategory, updateCategoryFailed, updateCategorySuccess
} from '../../../article/category/store/actions/category.actions';


@Injectable()
export class ProviderEffects {
    constructor(
        private readonly actions$: Actions,
        private readonly providerService: ProviderService,
        private readonly router: Router
    ) {}

    onLoadProviders$ = createEffect(() => this.actions$.pipe(
       ofType(loadProviders),
        switchMap(() =>
            this.providerService.getProviders().pipe(
                map(providers => loadProvidersSuccess({providers})),
                catchError((errorResponse) => of(loadProvidersFailed({errorResponse})))
            )
        ))
    );

    onLoadProviderById$ = createEffect(() => this.actions$.pipe(
        ofType(loadProviderById),
        switchMap((action) =>
            this.providerService.getProviderById(action.providerId).pipe(
                map((provider) => loadProviderByIdSuccess({ provider })),
                catchError((errorResponse) => of(loadProviderByIdFailed({ errorResponse })))
            )
        ))
    );

    onLoadProviderByIdSuccess$ = createEffect(() => this.actions$.pipe(
        ofType(loadProviderByIdSuccess),
        switchMap((action) => of(setSelectedProvider({provider: action.provider})))
    ));

    onAddCProvider$ = createEffect(() => this.actions$.pipe(
        ofType(addProvider),
        switchMap((action) =>
            this.providerService.createProvider(action.provider).pipe(
                map((provider) => addProviderSuccess({ provider })),
                catchError((errorResponse) => of(addProviderFailed({ errorResponse })))
            )
        ))
    );

    onUpdateProvider$ = createEffect(() => this.actions$.pipe(
        ofType(updateProvider),
        switchMap((action) =>
            this.providerService.updateProvider(action.provider).pipe(
                map((provider) => updateProviderSuccess({ provider })),
                catchError((errorResponse) => of(updateProviderFailed(errorResponse)))
            )
        )
        )
    );

    onDeleteProvider$ = createEffect(() => this.actions$.pipe(
        ofType(deleteProvider),
        switchMap((action) =>
            this.providerService.deleteProvider(action.id).pipe(
                map(() => deleteCategorySuccess({id: action.id})),
                catchError((errorResponse) => of(deleteCategoryFailed(errorResponse)))
            )
        )
        )
    );
}
