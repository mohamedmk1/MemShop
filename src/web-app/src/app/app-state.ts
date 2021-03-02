import {CoreState, getInitialCoreState} from './core/store';
import {CategoryState, getInitialCategoryState} from './modules/article/category/store/reducers/category.reducer';


export interface AppState {
    core: CoreState;
    category: CategoryState;
}

export const getInitialAppState: () => AppState = () => ({
    core: getInitialCoreState(),
    category: getInitialCategoryState()
});
