import {RouterModule, Routes} from '@angular/router';
import {ProviderPageComponent} from './container/provider-page/provider-page.component';
import {RouterPaths} from '../../shared/const/routing/router-path.constants';
import {PageNotFoundComponent} from '../../shared/components/page-not-found/page-not-found.component';
import {NgModule} from '@angular/core';
import { ProviderListComponent } from './components/provider-list/provider-list.component';
import {CategoryFormComponent} from '../article/category/components/category-form/category-form.component';
import {ProviderFormComponent} from './components/provider-form/provider-form.component';


const routes: Routes = [
    {
        path: '',
        component: ProviderPageComponent,
        children: [
            { path: 'list', component: ProviderListComponent},
            { path: 'edit/:id', component: ProviderFormComponent },
            {
                path: '',
                pathMatch: RouterPaths.PATHMATCH,
                redirectTo: 'list',
            },
            {
                path: RouterPaths.WILDCARD,
                component: PageNotFoundComponent,
            },
        ]
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProviderRoutingModule {}
