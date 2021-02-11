import {CustomMaterialModule} from '../modules/custom-material-module';
import {CommonModule} from '@angular/common';
import {HeaderComponent} from './components/header/header.component';
import {FooterComponent} from './components/footer/footer.component';
import {NgModule} from '@angular/core';
import {FlexLayoutModule} from '@angular/flex-layout';
import {RouterModule} from '@angular/router';

const modules = [
  CommonModule,
  CustomMaterialModule,
  FlexLayoutModule,
  RouterModule
];

const components = [
  HeaderComponent,
  FooterComponent
];

@NgModule({
  declarations: [...components],
  exports: [...modules, ...components],
  imports: [...modules]
})

export class SharedModule {}
