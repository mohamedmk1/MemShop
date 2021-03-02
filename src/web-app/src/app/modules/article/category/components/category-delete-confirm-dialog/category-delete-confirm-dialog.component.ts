import {ChangeDetectionStrategy, Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {Category} from '../../models/category.model';

@Component({
  selector: 'app-category-delete-confirm-dialog',
  templateUrl: './category-delete-confirm-dialog.component.html',
  styleUrls: ['./category-delete-confirm-dialog.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CategoryDeleteConfirmDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public category: Category) {}

  ngOnInit(): void {
  }

}
