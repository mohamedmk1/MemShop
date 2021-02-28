import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import {NgModule, Optional, SkipSelf} from '@angular/core';
import {throwIfAlreadyLoaded} from './module-import-guard';
import {AppStateFeatures} from '../app-state-features';
import {reducers} from './store';
import {DefaultRouterStateSerializer, StoreRouterConnectingModule} from '@ngrx/router-store';
import { StoreModule } from '@ngrx/store';
import {StoreDevtoolsModule} from '@ngrx/store-devtools';
import {EffectsModule} from '@ngrx/effects';

export const modules = [BrowserModule, BrowserAnimationsModule, HttpClientModule];

@NgModule({
  imports: [
    ...modules,
    StoreModule.forRoot(
        {},
        {
          runtimeChecks: {
            strictStateImmutability: true,
            strictActionImmutability: true,
          },
        }
    ),
    StoreModule.forFeature(AppStateFeatures.Core, reducers),
    StoreDevtoolsModule.instrument({
      maxAge: 50,
      name: 'Demo Shop state',
    }),
    StoreRouterConnectingModule.forRoot({ serializer: DefaultRouterStateSerializer }),
    EffectsModule.forRoot([]),
    EffectsModule.forFeature([]),
  ],
})

export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
