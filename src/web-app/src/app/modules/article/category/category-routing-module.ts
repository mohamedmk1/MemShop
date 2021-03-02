import {RouterModule, Routes} from '@angular/router';
import {CategoryPageComponent} from './container/category-page/category-page.component';
import {CategoryListComponent} from './components/category-list/category-list.component';
import {CategoryFormComponent} from './components/category-form/category-form.component';
import {RouterPaths} from '../../../shared/const/routing/router-path.constants';
import {NgModule} from '@angular/core';
import {PageNotFoundComponent} from '../../../shared/components/page-not-found/page-not-found.component';


const routes: Routes = [
    {
        path: '',
        component: CategoryPageComponent,
        children: [
            { path: 'list', component: CategoryListComponent },
            { path: 'edit/:id', component: CategoryFormComponent },
            {
                path: '',
                pathMatch: RouterPaths.PATHMATCH,
                redirectTo: 'list',
            },
            {
                path: RouterPaths.WILDCARD,
                component: PageNotFoundComponent,
            },
        ],
    },
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CategoryRoutingModule {}
