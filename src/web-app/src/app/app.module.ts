import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {CoreModule} from './core/core.module';
import {SharedModule} from './shared/shared.module';
import {AppRoutingModule} from './app-routing.module';

const modules = [
    CoreModule,
    AppRoutingModule,
    SharedModule];

const components = [AppComponent];

@NgModule({
    declarations: [...components],
    imports: [...modules],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
