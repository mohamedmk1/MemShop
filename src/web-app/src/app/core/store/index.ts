import * as fromRouter from '@ngrx/router-store';
import {AppRouterState} from '../models/router-state';
import {ActionReducerMap, createFeatureSelector, createSelector} from '@ngrx/store';
import {AppStateFeatures} from '../../app-state-features';

export interface CoreState {
    router: fromRouter.RouterReducerState<AppRouterState>;
}

export const getInitialCoreState: () => CoreState = () => ({
   router: {
       state: {
           feature: '',
           url: '',
           params: {},
           queryParams: {},
       },
       navigationId: 0,
   }
});

export const reducers: ActionReducerMap<CoreState> = {
    router: fromRouter.routerReducer
};

const selectCoreState = createFeatureSelector<CoreState>(AppStateFeatures.Core);

/** Router */
export const selectRouterParams = createSelector(selectCoreState,
    (state) => state.router && state.router.state.params);
