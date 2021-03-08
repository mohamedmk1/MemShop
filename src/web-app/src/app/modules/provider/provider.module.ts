import {NgModule} from '@angular/core';
import {ProviderPageComponent} from './container/provider-page/provider-page.component';
import {ProviderListComponent} from './components/provider-list/provider-list.component';
import {CommonModule} from '@angular/common';
import {StoreModule} from '@ngrx/store';
import {AppStateFeatures} from '../../app-state-features';
import {EffectsModule} from '@ngrx/effects';
import {SharedModule} from '../../shared/shared.module';
import {providerReducer} from './store/reducers/provider.reducer';
import {ProviderEffects} from './store/effects/provider.effects';
import {ProviderRoutingModule} from './provider.routing.module';
import { ProviderFormComponent } from './components/provider-form/provider-form.component';
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
    declarations: [ProviderPageComponent, ProviderListComponent, ProviderFormComponent],
    imports: [
        CommonModule,
        ProviderRoutingModule,
        StoreModule.forFeature(AppStateFeatures.Provider, providerReducer),
        EffectsModule.forFeature([ProviderEffects]),
        SharedModule,
        ReactiveFormsModule
    ],
    providers: [ProviderEffects]
})
export class ProviderModule {}
