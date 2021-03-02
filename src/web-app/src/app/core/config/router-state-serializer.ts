import {Injectable} from '@angular/core';
import {RouterStateSerializer} from '@ngrx/router-store';
import {AppRouterState} from '../models/router-state';
import {ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';
import {AppStateFeatures} from '../../app-state-features';
import {SharedUtils} from '../../shared/utils/shared-utils';

@Injectable()
export class AppRouterStateSerializer implements RouterStateSerializer<AppRouterState> {
    serialize(routerState: RouterStateSnapshot): AppRouterState {
        const { url } = routerState;
        const feature: string = this.getFeature(url);
        const { queryParams } = routerState.root;
        let routeSnapshot: ActivatedRouteSnapshot = routerState.root;
        while (routeSnapshot.firstChild) {
            routeSnapshot = routeSnapshot.firstChild;
        }
        const { params } = routeSnapshot;
        return { feature, url, params, queryParams };
    }

    getFeature(url: string): string {
        for (const feature in AppStateFeatures) {
            if (url.startsWith(`/${SharedUtils.camelToKebabCase(feature)}`)) {
                return feature;
            }
        }
        return undefined;
    }
}
