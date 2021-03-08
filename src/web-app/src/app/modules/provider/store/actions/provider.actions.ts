import {createAction, props} from '@ngrx/store';
import {List} from 'immutable';
import {HttpErrorResponse} from '@angular/common/http';
import {ProviderModel} from '../../models/provider.model';


export const loadProviders = createAction('[ProviderManagement] Load providers');

export const loadProvidersSuccess = createAction(
    '[ProviderManagement] Load providers SUCCESS',
    props<{ providers: List<ProviderModel> }>()
);

export const loadProvidersFailed = createAction(
    '[ProviderManagement] Load providers FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const loadProviderById = createAction(
    '[ProviderManagement] Load provider by id',
    props<{ providerId: number }>()
);

export const loadProviderByIdSuccess = createAction(
    '[ProviderManagement] Load provider by id SUCCESS',
    props<{ provider: ProviderModel }>()
);

export const loadProviderByIdFailed = createAction(
    '[ProviderManagement] Load provider by id FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const addProvider = createAction(
    '[ProviderManagement] Add provider',
    props<{ provider: ProviderModel }>()
);

export const addProviderSuccess = createAction(
    '[ProviderManagement] Add provider SUCCESS',
    props<{ provider: ProviderModel }>()
);

export const addProviderFailed = createAction(
    '[ProviderManagement] Add provider FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const updateProvider = createAction(
    '[ProviderManagement] Update provider',
    props<{ provider: ProviderModel}>()
);

export const updateProviderSuccess = createAction(
    '[ProviderManagement] Update provider SUCCESS',
    props<{ provider: ProviderModel}>()
);

export const updateProviderFailed = createAction(
    '[ProviderManagement] Update provider FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const deleteProvider = createAction(
    '[ProviderManagement] Delete provider',
    props<{ id: number}>()
);

export const deleteProviderSuccess = createAction(
    '[ProviderManagement] Delete provider SUCCESS',
    props<{ id: number}>()
);

export const deleteProviderFailed = createAction(
    '[ProviderManagement] Delete provider FAILED',
    props<{ errorResponse: HttpErrorResponse }>()
);

export const clearProviders = createAction('[ProviderManagement] Clear providers');

export const setSelectedProvider = createAction(
    '[ProviderManagement] Set selected provider',
    props<{ provider: ProviderModel }>()
);

export const clearSelectedProvider = createAction('[ProviderManagement] Clear selected provider');
