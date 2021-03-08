import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {selectRouterParams} from '../../../../core/store';
import {first, tap} from 'rxjs/operators';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../app-state';
import {loadProviderById} from '../../store/actions/provider.actions';
import {selectSelectedProvider} from '../../store';
import {ProviderModel} from '../../models/provider.model';

@Component({
  selector: 'app-provider-form',
  templateUrl: './provider-form.component.html',
  styleUrls: ['./provider-form.component.scss']
})
export class ProviderFormComponent implements OnInit {
    id: string;
    providerForm: FormGroup;
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
                    this.store.dispatch(loadProviderById({ providerId: Number(this.id) }));
                    this.store
                        .select(selectSelectedProvider)
                        .pipe(first((data) => !!data))
                        .subscribe(this.initForm.bind(this));
                }
            });
    }

    private initForm(provider: ProviderModel): void {
        this.providerForm = new FormGroup({
            name: new FormControl(provider && provider.name ? provider.name : null, [
                Validators.required,
                Validators.minLength(5),
                Validators.maxLength(50),
            ]),
            address: new FormControl(provider && provider.address ? provider.address : null, [
                Validators.required,
                Validators.maxLength(120)
            ]),
            zipCode: new FormControl(provider && provider.zipCode ? provider.zipCode : null, [
                Validators.required,
                Validators.maxLength(5),
            ]),
            country: new FormControl(provider && provider.country ? provider.country : null, [
                Validators.required,
                Validators.maxLength(50),
            ])
        });

        this.cd.markForCheck();
    }

    onSubmit(): void {

    }
}
