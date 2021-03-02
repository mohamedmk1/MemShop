import {Component, OnInit} from '@angular/core';
import {AppState} from './app-state';
import {Store} from '@ngrx/store';
import {applicationInit} from './core/store/actions/core.actions';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'web-app';

    constructor(private readonly store: Store<AppState>) {}

    ngOnInit(): void {
        this.store.dispatch(applicationInit());
    }
}
