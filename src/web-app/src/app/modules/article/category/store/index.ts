import {createFeatureSelector, createSelector} from '@ngrx/store';
import {CategoryState} from './reducers/category.reducer';
import {AppStateFeatures} from '../../../../app-state-features';

const categoryFeatureState = createFeatureSelector<CategoryState>(AppStateFeatures.Category);

export const selectCategories = createSelector(
    categoryFeatureState,
    state => state.categories
);

export const selectSelectedCategory = createSelector(
    categoryFeatureState,
    state => state.selectedCategory
);
