import {Component, OnInit} from '@angular/core';
import {AppState} from './app-state';
import {Store} from '@ngrx/store';
import {applicationInit} from './core/store/actions/core.actions';
import {selectRouterFeature} from './core/store';
import {first, tap} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {AppStateFeatures} from './app-state-features';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'web-app';
    feature$: Observable<string>

    constructor(private readonly store: Store<AppState>) {}

    ngOnInit(): void {
        this.store.dispatch(applicationInit());

        this.feature$ = this.store.select(selectRouterFeature);
    }
}
