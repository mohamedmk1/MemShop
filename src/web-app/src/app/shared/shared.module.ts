import {CommonModule} from '@angular/common';
import {HeaderComponent} from './components/header/header.component';
import {FooterComponent} from './components/footer/footer.component';
import {NgModule} from '@angular/core';
import {FlexLayoutModule} from '@angular/flex-layout';
import {RouterModule} from '@angular/router';
import { LeftMenuComponent } from './components/left-menu/left-menu.component';
import { NavHeaderComponent } from './components/nav-header/nav-header.component';
import {CustomMaterialModule} from './modules/custom-material.module';
import {PageNotFoundComponent} from './components/page-not-found/page-not-found.component';

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
  declarations: [...components, LeftMenuComponent, NavHeaderComponent, PageNotFoundComponent],
  exports: [...modules, ...components, LeftMenuComponent, NavHeaderComponent],
  imports: [...modules]
})

export class SharedModule {}
