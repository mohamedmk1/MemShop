import {Component, OnInit, ViewChild} from '@angular/core';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {Category} from '../../models/category.model';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../../app-state';
import {List} from 'immutable';
import {selectCategories} from '../../store';
import {deleteCategory, loadCategories} from '../../store/actions/category.actions';
import {Observable} from 'rxjs';
import {CategoryDeleteConfirmDialogComponent} from '../category-delete-confirm-dialog/category-delete-confirm-dialog.component';
import {MatDialog} from '@angular/material/dialog';
import {filter} from 'rxjs/operators';

@Component({
    selector: 'app-category-list',
    templateUrl: './category-list.component.html',
    styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {

    @ViewChild(MatSort) sort: MatSort;

    dataSource: MatTableDataSource<Category>;
    readonly displayedColumns: string[] = [
        'id',
        'label',
        'actions'
    ];

    categories$: Observable<List<Category>> = this.store.select(selectCategories);

    constructor(private readonly store: Store<AppState>,
                private readonly dialog: MatDialog) {
        this.dataSource = new MatTableDataSource<Category>();
    }

    ngOnInit(): void {
        this.store.dispatch(loadCategories());
        this.categories$
            .subscribe(categories => this.dataSource.data = categories.toArray());
    }

    selectCategory(id: number): void {
    }

    deleteCategory(id: number): void {
        this.dialog.open(CategoryDeleteConfirmDialogComponent, {
            width: '400px',
            autoFocus: false,
            data: id
        }).afterClosed().pipe(
            filter(Boolean)
        ).subscribe(() => {
            this.store.dispatch(deleteCategory({id}));
        });
    }
}
