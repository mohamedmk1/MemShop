import {createEntityAdapter, EntityAdapter, EntityState} from '@ngrx/entity';
import {ProviderModel} from '../../models/provider.model';
import {List} from 'immutable';
import {Action, createReducer, on} from '@ngrx/store';
import {
    addProviderSuccess, clearProviders, clearSelectedProvider, deleteProviderSuccess,
    loadProviderByIdSuccess,
    loadProvidersSuccess, setSelectedProvider,
    updateProviderSuccess
} from '../actions/provider.actions';
import {CategoryState} from '../../../article/category/store';

export interface ProviderState extends EntityState<ProviderModel> {
    providers: List<ProviderModel>;
    selectedProvider: ProviderModel;
}

export const adapter: EntityAdapter<ProviderModel> = createEntityAdapter<ProviderModel>();

export const getInitialProviderState: () => ProviderState = () =>
    adapter.getInitialState({
        providers: List(),
        selectedProvider: null
    });

const _providerReducer = createReducer(
    getInitialProviderState(),
    // Get providers
    on(loadProvidersSuccess, (state: ProviderState, action) => {
        return {
            ...state,
            providers: List(action.providers)
        };
    }),
    // Add provider
    on(addProviderSuccess, (state: ProviderState, action) => {
        return {
            ...state,
            providers: state.providers.push(action.provider)
        };
    }),

    // Update provider
    on(updateProviderSuccess, (state: ProviderState, action) => {
        return {
            ...state,
            providers: state.providers.map(provider => {
                if (action.provider.id === provider.id) {
                    return action.provider;
                }
                return provider;
            })
        };
    }),

    // Get provider by id
    on(loadProviderByIdSuccess, (state: ProviderState, action) => {
        return {
            ...state,
            selectedProvider: action.provider
        };
    }),

    // Delete provider
    on(deleteProviderSuccess, (state: ProviderState, action) => {
        return {
            ...state,
            providers: state.providers.filter(provider => provider.id !== action.id)
        };
    }),

    // Set selected provider
    on(setSelectedProvider, (state: ProviderState, action) => {
        return {
            ...state,
            provider: action.provider
        };
    }),

    // Clear category store
    on(clearProviders, (state) => {
        return {
            ...state,
            providers: List()
        };
    }),
    on(clearSelectedProvider, (state) => {
        return {
            ...state,
            selectedProvider: null
        };
    }),
);

export function providerReducer(state: ProviderState | undefined, action: Action): any {
    return _providerReducer(state, action);
}
