import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {CoreModule} from './core/core.module';
import {SharedModule} from './shared/shared.module';
import {AppRoutingModule} from './app-routing.module';
import {StoreModule} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';

const modules = [CoreModule, AppRoutingModule, SharedModule,
  StoreModule.forRoot({}), EffectsModule.forRoot([])];

const components = [AppComponent];

@NgModule({
  declarations: [...components],
  imports: [...modules],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
