import {RouterModule, Routes} from '@angular/router';
import {RouterPaths} from './shared/const/router-path.constants';
import {NgModule} from '@angular/core';

export const routes: Routes = [
  {
    path: '',
    pathMatch: RouterPaths.PATHMATCH,
    redirectTo: RouterPaths.DASHBOARD.BASE.path,
  },
  {
    loadChildren: () => import('./modules/dashboard/dashboard.module').then((m) => m.DashboardModule),
    path: RouterPaths.DASHBOARD.BASE.path
  }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule {}