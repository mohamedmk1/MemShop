import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryDeleteConfirmDialogComponent } from './category-delete-confirm-dialog.component';

describe('CategoryDeleteConfirmDialogComponent', () => {
  let component: CategoryDeleteConfirmDialogComponent;
  let fixture: ComponentFixture<CategoryDeleteConfirmDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryDeleteConfirmDialogComponent ]
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
