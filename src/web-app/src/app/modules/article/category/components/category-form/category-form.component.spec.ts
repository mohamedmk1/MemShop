import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryFormComponent } from './category-form.component';
import {SharedModule} from '../../../../../shared/shared.module';
import {EffectsModule} from '@ngrx/effects';
import {RouterTestingModule} from '@angular/router/testing';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';
import {MockStore, provideMockStore} from '@ngrx/store/testing';
import {AppState, getInitialAppState} from '../../../../../app-state';
import {Store} from '@ngrx/store';
import {Category} from '../../models/category.model';
import {List} from 'immutable';
import {
    addCategory,
    clearSelectedCategory,
    loadCategoryById,
    updateCategory
} from '../../store/actions/category.actions';

describe('CategoryFormComponent', () => {
    let component: CategoryFormComponent;
    let fixture: ComponentFixture<CategoryFormComponent>;
    let store: MockStore<AppState>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [
                SharedModule,
                EffectsModule.forRoot([]),
                RouterTestingModule.withRoutes([]),
                BrowserAnimationsModule,
                ReactiveFormsModule
            ],
            declarations: [ CategoryFormComponent ],
            providers: [
                provideMockStore({ initialState: getInitialAppState() })
            ]
        })
            .compileComponents();
    });

    beforeEach(() => {
        store = TestBed.inject(Store) as MockStore<AppState>;
        fixture = TestBed.createComponent(CategoryFormComponent);
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

        it('should not initialize category form when route is undefined', () => {
            // Act
            component.ngOnInit();

            // Assert
            expect(component.categoryForm).toBeUndefined();
        });

        it('should initialize category form with null value ' +
            'when route is defined and params is new', () => {
            // Arrange
            const state = getInitialAppState();
            state.core.router.state.params = {
                id: 'new'
            };
            store.setState(state);

            // Act
            component.ngOnInit();

            // Assert
            expect(component.categoryForm).toBeDefined();
            expect(component.categoryForm.controls.label.value).toBeNull();
            expect(component.categoryForm.controls.description.value).toBeNull();
        });

        it('should initialize category form with category value ' +
            'when route is defined and params is 1', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');
            const categoryId = 1;
            const category = Category
                .newBuilder()
                .withId(categoryId)
                .withLabel('category 1')
                .withDescription('desc category 1')
                .build();
            const state = getInitialAppState();
            state.core.router.state.params = {
                id: categoryId.toString()
            };
            state.category.categories = List.of(category);
            state.category.selectedCategory = category;
            store.setState(state);

            // Act
            component.ngOnInit();

            // Assert
            expect(component.categoryForm).toBeDefined();
            expect(component.categoryForm.controls.label.value).toEqual('category 1');
            expect(component.categoryForm.controls.description.value).toEqual('desc category 1');
            expect(dispatchSpy).toHaveBeenCalledTimes(1);
            expect(dispatchSpy).toHaveBeenCalledWith(loadCategoryById({categoryId}));
        });
    });

    describe('ngOnDestroy', () => {
        it('should dispatch clearSelectedCategory when destroy', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');

            // Act
            component.ngOnDestroy();

            // Assert
            expect(dispatchSpy).toHaveBeenCalledTimes(1);
            expect(dispatchSpy).toHaveBeenCalledWith(clearSelectedCategory());
        });
    });

    describe('onSubmit()', () => {
        beforeEach(() => {
            fixture.detectChanges();
        });

        it('should not validate form when description is too long', () => {
            // Arrange
            const category = Category
                .newBuilder()
                .withId(1)
                .withLabel('category 1')
                .withDescription('Lorem Ipsum is simply dummy text of the printing and typesetting industry.' +
                    ' Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, ' +
                    'when an unknown printer took a galley of type and scrambled it to make a type specimen book. ' +
                    'It has survived not only five centuries, but also the leap into electronic typesetting, ' +
                    'remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset ' +
                    'sheets containing Lorem Ipsum passages, ' +
                    'and more recently with desktop publishing software ' +
                    'like Aldus PageMaker including versions of Lorem Ipsum')
                .build();
            component.initForm(category);

            // Act
            component.onSubmit();

            expect(component.categoryForm.valid).toBeFalsy();
        });

        it('should dispatch addCategory with category value when value is new', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');
            const category = Category
                .newBuilder()
                .withId(1)
                .withLabel('category 1')
                .withDescription('Lorem Ipsum is simply dummy text of the printing and typesetting industry')
                .build();
            component.initForm(category);
            component.isNew = true;
            const expectedResult = Category
                .newBuilder()
                .withLabel('category 1')
                .withDescription('Lorem Ipsum is simply dummy text of the printing and typesetting industry')
                .build();

            // Act
            component.onSubmit();

            expect(dispatchSpy).toHaveBeenCalledTimes(1);
            expect(dispatchSpy).toHaveBeenCalledWith(addCategory({category: expectedResult}));
        });

        it('should dispatch updateCategory with category value when value is update', () => {
            // Arrange
            const dispatchSpy = jest.spyOn(store, 'dispatch');
            const category = Category
                .newBuilder()
                .withId(1)
                .withLabel('category 1')
                .withDescription('Lorem Ipsum is simply dummy text of the printing and typesetting industry')
                .build();
            component.initForm(category);
            component.isNew = false;
            const expectedResult = Category
                .newBuilder()
                .withLabel('category 1')
                .withDescription('Lorem Ipsum is simply dummy text of the printing and typesetting industry')
                .build();

            // Act
            component.onSubmit();

            expect(dispatchSpy).toHaveBeenCalledTimes(1);
            expect(dispatchSpy).toHaveBeenCalledWith(updateCategory({category: expectedResult}));
        });
    });

    describe('initForm()', () => {
        it('should initialize form with category value', () => {
            // Arrange
            const category = Category
                .newBuilder()
                .withId(1)
                .withLabel('category 1')
                .withDescription('Lorem Ipsum is simply dummy text of the printing and typesetting industry')
                .build();

            // Act
            component.initForm(category);

            // Assert
            expect(component.categoryForm.controls.label.value).toEqual(category.label);
            expect(component.categoryForm.controls.description.value).toEqual(category.description);
        });
    });
});
