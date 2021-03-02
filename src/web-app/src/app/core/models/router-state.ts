import { Params } from '@angular/router';

export interface AppRouterState {
    feature: string;
    url: string;
    params: Params;
    queryParams: Params;
}
