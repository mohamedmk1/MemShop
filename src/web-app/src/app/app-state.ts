import {CoreState, getInitialCoreState} from './core/store';


export interface AppState {
    core: CoreState;
}

export const getInitialAppState: () => AppState = () => ({
    core: getInitialCoreState()
});
