import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryDeleteConfirmDialogComponent } from './category-delete-confirm-dialog.component';
import {SharedModule} from '../../../../../shared/shared.module';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {Category} from '../../models/category.model';

describe('CategoryDeleteConfirmDialogComponent', () => {
    let component: CategoryDeleteConfirmDialogComponent;
    let fixture: ComponentFixture<CategoryDeleteConfirmDialogComponent>;
    const category = Category.newBuilder().build();

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [SharedModule],
            declarations: [ CategoryDeleteConfirmDialogComponent ],
            providers: [
                {provide: MAT_DIALOG_DATA, useValue: category}
            ]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CategoryDeleteConfirmDialogComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
