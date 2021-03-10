import {createFeatureSelector, createSelector} from '@ngrx/store';
import {ProviderState} from './reducers/provider.reducer';
import {AppStateFeatures} from '../../../app-state-features';

export * from './reducers/provider.reducer';

const providerFeatureState = createFeatureSelector<ProviderState>(AppStateFeatures.Provider);

export const selectProviders = createSelector(
    providerFeatureState,
    state => state.providers
);

export const selectSelectedProvider = createSelector(
    providerFeatureState,
    state => state.selectedProvider
);
