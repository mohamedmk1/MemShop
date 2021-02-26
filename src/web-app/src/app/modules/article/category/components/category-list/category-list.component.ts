import {Component, OnInit, ViewChild} from '@angular/core';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {Category} from '../../models/category.model';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../../app-state';
import {Observable} from 'rxjs';
import {List} from 'immutable';
import {selectCategories} from '../../store';
import {loadCategories} from '../../store/actions/category.actions';

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
        'label'
    ];

    categories$: Observable<List<Category>> = this.store.select(selectCategories);

    constructor(private readonly store: Store<AppState>) {
        this.dataSource = new MatTableDataSource<Category>();
    }

    ngOnInit(): void {
        this.store.dispatch(loadCategories());
    }

    selectCategory(id: number): void {
    }
}
