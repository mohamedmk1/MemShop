import {ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../../app-state';
import {selectRouterParams} from '../../../../../core/store';
import {first, tap} from 'rxjs/operators';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {
    addCategory,
    clearSelectedCategory,
    loadCategoryById,
    updateCategory
} from '../../store/actions/category.actions';
import {selectSelectedCategory} from '../../store';
import {Category} from '../../models/category.model';

@Component({
    selector: 'app-category-form',
    templateUrl: './category-form.component.html',
    styleUrls: ['./category-form.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CategoryFormComponent implements OnInit, OnDestroy {
    id: string;
    categoryForm: FormGroup;
    isNew: boolean;

    constructor(private readonly store: Store<AppState>, private readonly cd: ChangeDetectorRef) { }

    ngOnInit(): void {
        this.store
            .select(selectRouterParams)
            .pipe(
                first((data) => !!data),
                tap((params) => {
                    this.id = params.id;
                    this.isNew = this.id === 'new';
                })
            )
            .subscribe((params) => {
                this.id = params.id;

                this.isNew = this.id === 'new';

                if (this.isNew) {
                    this.initForm(null);
                } else {
                    this.store.dispatch(loadCategoryById({ categoryId: Number(this.id) }));
                    this.store
                        .select(selectSelectedCategory)
                        .pipe(first((data) => !!data))
                        .subscribe(this.initForm.bind(this));
                }
            });
    }

    ngOnDestroy(): void {
        this.store.dispatch(clearSelectedCategory());
    }

    onSubmit(): void {
        if (this.categoryForm.valid) {
            if (this.isNew) {
                this.store.dispatch(addCategory({ category: this.categoryForm.value }));
            } else {
                const categoryPayload: Category = {
                    ...this.categoryForm.value,
                    id: this.id
                };

                this.store.dispatch(updateCategory({category: categoryPayload }));
            }
        }
    }

    public initForm(category: Category): void {
        this.categoryForm = new FormGroup({
            label: new FormControl(category && category.label ? category.label : null, [
                Validators.required,
                Validators.minLength(5),
                Validators.maxLength(50),
            ]),
            description: new FormControl(category && category.description ? category.description : null, [
                Validators.maxLength(255)
            ])
        });

        this.cd.markForCheck();
    }
}
