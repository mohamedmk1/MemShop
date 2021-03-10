import {ChangeDetectionStrategy, Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {ProviderModel} from '../../models/provider.model';

@Component({
  selector: 'app-provider-delete-confirm-dialog',
  templateUrl: './provider-delete-confirm-dialog.component.html',
  styleUrls: ['./provider-delete-confirm-dialog.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProviderDeleteConfirmDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public provider: ProviderModel) { }

  ngOnInit(): void {
  }

}
