import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {Category} from '../../../article/category/models/category.model';
import {ProviderModel} from '../../models/provider.model';
import {Observable} from 'rxjs';
import {List} from 'immutable';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../app-state';
import {selectProviders} from '../../store';
import {deleteProvider, loadProviders} from '../../store/actions/provider.actions';
import {CategoryDeleteConfirmDialogComponent} from '../../../article/category/components/category-delete-confirm-dialog/category-delete-confirm-dialog.component';
import {filter} from 'rxjs/operators';
import {ProviderDeleteConfirmDialogComponent} from '../provider-delete-confirm-dialog/provider-delete-confirm-dialog.component';
import {MatDialog} from '@angular/material/dialog';

@Component({
    selector: 'app-provider-list',
    templateUrl: './provider-list.component.html',
    styleUrls: ['./provider-list.component.scss']
})
export class ProviderListComponent implements OnInit {

    dataSource: MatTableDataSource<ProviderModel>;
    readonly displayedColumns: string[] = [
        'id',
        'name',
        'address',
        'actions'
    ];

    providers$: Observable<List<ProviderModel>> = this.store.select(selectProviders);

    constructor(private readonly store: Store<AppState>,
                private readonly dialog: MatDialog) {
        this.dataSource = new MatTableDataSource<ProviderModel>();
    }

    ngOnInit(): void {
        this.store.dispatch(loadProviders());
        this.providers$
            .subscribe(providers => this.dataSource.data = providers.toArray());
    }

    deleteProvider(id: number): void {
        this.dialog.open(ProviderDeleteConfirmDialogComponent, {
            width: '400px',
            autoFocus: false,
            data: id
        }).afterClosed().pipe(
            filter(Boolean)
        ).subscribe(() => {
            this.store.dispatch(deleteProvider({id}));
        });
    }
}
