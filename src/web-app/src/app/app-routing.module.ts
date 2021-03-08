import {RouterModule, Routes} from '@angular/router';
import {RouterPaths} from './shared/const/routing/router-path.constants';
import {NgModule} from '@angular/core';

export const routes: Routes = [
  {
    loadChildren: () => import('./modules/provider/provider.module').then((m) => m.ProviderModule),
    path: RouterPaths.PROVIDERS.BASE.path,
  },
  {
    loadChildren: () => import('./modules/article/category/category.module').then((m) => m.CategoryModule),
    path: RouterPaths.ARTICLES.CATEGORY.path,
  },
  {
    loadChildren: () => import('./modules/dashboard/dashboard.module').then((m) => m.DashboardModule),
    path: RouterPaths.DASHBOARD.BASE.path
  },
  {
    path: '',
    pathMatch: RouterPaths.PATHMATCH,
    redirectTo: RouterPaths.DASHBOARD.BASE.path,
  }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule {}
