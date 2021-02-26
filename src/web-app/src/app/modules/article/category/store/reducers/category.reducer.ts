import {Category} from '../../models/category.model';
import {List} from 'immutable';
import {createEntityAdapter, EntityAdapter, EntityState} from '@ngrx/entity';
import {Action, createReducer, on} from '@ngrx/store';
import {
    addCategorySuccess, clearCategories, clearSelectedCategory,
    deleteCategorySuccess,
    loadCategoriesSuccess, loadCategoryByIdSuccess,
    updateCategorySuccess
} from '../actions/category.actions';

export interface CategoryState extends EntityState<Category> {
    categories: List<Category>;
    selectedCategory: Category;
}

export const adapter: EntityAdapter<Category> = createEntityAdapter<Category>();

export const getInitialCategoryState: () => CategoryState = () =>
    adapter.getInitialState({
        categories: List(),
        selectedCategory: null
    });

const _categoryReducer = createReducer(
    getInitialCategoryState(),
    // Get categories
    on(loadCategoriesSuccess, (state: CategoryState, action) => {
        return {
            ...state,
            categories: action.categories
        };
    }),

    // Add category
    on(addCategorySuccess, (state: CategoryState, action) => {
      return {
          ...state,
          categories: state.categories.push(action.category)
      };
    }),

    // Update category
    on(updateCategorySuccess, (state: CategoryState, action) => {
        return {
            ...state,
            categories: state.categories.map(category => {
               if (action.category.id === category.id) {
                   return action.category;
               }
               return category;
            })
        };
    }),

    // Get category by id
    on(loadCategoryByIdSuccess, (state: CategoryState, action) => {
        return {
            ...state,
            selectedCategory: action.category
        };
    }),

    // Delete category
    on(deleteCategorySuccess, (state: CategoryState, action) => {
        return {
            ...state,
            categories: state.categories.filter(category => category.id !== action.id)
        };
    }),

    // Clear category store
    on(clearCategories, (state) => {
        return {
            ...state,
            categories: List()
        };
    }),
    on(clearSelectedCategory, (state) => {
        return {
            ...state,
            selectedCategory: null
        };
    }),
);

export function categoryReducer(state: CategoryState | undefined, action: Action): any {
    return _categoryReducer(state, action);
}
