import {CategoryPageComponent} from './container/category-page/category-page.component';
import {CategoryListComponent} from './components/category-list/category-list.component';
import {CategoryFormComponent} from './components/category-form/category-form.component';
import {CommonModule} from '@angular/common';
import {StoreModule} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {SharedModule} from '../../../shared/shared.module';
import {ReactiveFormsModule} from '@angular/forms';
import {NgModule} from '@angular/core';
import {categoryReducer} from './store/reducers/category.reducer';
import {CategoryEffects} from './store/effects/category.effects';
import {AppStateFeatures} from '../../../app-state-features';
import {CategoryRoutingModule} from './category-routing-module';


@NgModule({
    declarations: [CategoryPageComponent, CategoryListComponent, CategoryFormComponent],
    imports: [
        CommonModule,
        CategoryRoutingModule,
        StoreModule.forFeature(AppStateFeatures.Category, categoryReducer),
        EffectsModule.forFeature([CategoryEffects]),
        SharedModule,
        ReactiveFormsModule,
    ],
    providers: [CategoryEffects]
})
export class CategoryModule {}
