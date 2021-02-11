import {RouterModule, Routes} from '@angular/router';
import {DashboardComponent} from './container/dashboard/dashboard.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
  {
    component: DashboardComponent,
    path: ''
  },
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forChild(routes)],
})
export class DashboardRoutingModule {}
