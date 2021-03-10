import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderDeleteConfirmDialogComponent } from './provider-delete-confirm-dialog.component';

describe('ProviderDeleteConfirmDialogComponent', () => {
  let component: ProviderDeleteConfirmDialogComponent;
  let fixture: ComponentFixture<ProviderDeleteConfirmDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProviderDeleteConfirmDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderDeleteConfirmDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
