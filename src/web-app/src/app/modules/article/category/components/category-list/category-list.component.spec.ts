import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryListComponent } from './category-list.component';
import {RouterTestingModule} from '@angular/router/testing';
import {EffectsModule} from '@ngrx/effects';
import {Store} from '@ngrx/store';
import {Category} from '../../models/category.model';
import {List} from 'immutable';
import {deleteCategory, loadCategories} from '../../store/actions/category.actions';
import {MockStore, provideMockStore} from '@ngrx/store/testing';
import {AppState, getInitialAppState} from '../../../../../app-state';
import {SharedModule} from '../../../../../shared/shared.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatDialog} from '@angular/material/dialog';
import {MatDialogMock} from '../../../../../shared/mocks/mat-dialog.mock';
import {of} from 'rxjs';

describe('CategoryListComponent', () => {
    let component: CategoryListComponent;
    let fixture: ComponentFixture<CategoryListComponent>;
    let store: MockStore<AppState>;
    let dialog: MatDialog;

    const category1 = Category
        .newBuilder()
        .withId(1)
        .withLabel('category 1')
        .build();

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [
                SharedModule,
                EffectsModule.forRoot([]),
                RouterTestingModule.withRoutes([]),
                BrowserAnimationsModule
            ],
            providers: [
                provideMockStore({ initialState: getInitialAppState() }),
                { provide: MatDialog, useClass: MatDialogMock }
            ],
            declarations: [ CategoryListComponent ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        store = TestBed.inject(Store) as MockStore<AppState>;
        dialog = TestBed.inject(MatDialog);
        fixture = TestBed.createComponent(CategoryListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    describe('ngOnInit()', () => {
        beforeEach(() => {
            fixture.detectChanges();
        });

        it('should dispatch load categories action', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');

            // Act
            component.ngOnInit();

            // Assert
            expect(dispatchSpy).toHaveBeenCalledTimes(1);
            expect(dispatchSpy).toHaveBeenCalledWith(loadCategories());
        });

        it('should not have a category data source', () => {
            // Arrange
            const expectedDataSource = [];

            // Act
            component.ngOnInit();

            // Assert
            expect(component.dataSource.data).toEqual(expectedDataSource);
        });

        it('should have a category data source', () => {
            // Arrange
            const state = getInitialAppState();
            state.category.categories = List.of(category1);
            store.setState(state);

            // Act
            component.ngOnInit();

            // Assert
            expect(component.dataSource.data).toEqual([category1]);
        });
    });

    describe('deleteCategory()', () => {
        it('should not dispatch deleteCategory action when id is null', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');
            const id = null;
            spyOn(dialog, 'open')
                .and
                .returnValue({afterClosed: () => of(id)});
            fixture.detectChanges();

            component.deleteCategory(id);

            expect(dispatchSpy).toHaveBeenCalledTimes(0);
        });

        it('should dispatch deleteCategory action when id exists', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');
            const id = 1;
            spyOn(dialog, 'open')
                .and
                .returnValue({afterClosed: () => of(id)});
            fixture.detectChanges();

            component.deleteCategory(id);

            expect(dispatchSpy).toHaveBeenCalledTimes(1);
            expect(dispatchSpy).toHaveBeenCalledWith(deleteCategory({id}));
        });
    });
});
