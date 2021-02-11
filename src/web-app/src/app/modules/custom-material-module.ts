import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {NgModule} from '@angular/core';
import {MatGridListModule} from '@angular/material/grid-list';

const modules = [
  MatToolbarModule,
  MatIconModule,
  MatGridListModule
];

@NgModule({
  exports: [...modules],
  imports: [...modules],
})

export class CustomMaterialModule {}
