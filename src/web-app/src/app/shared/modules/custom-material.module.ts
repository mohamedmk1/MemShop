import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';

const modules = [
    MatTableModule,
    MatToolbarModule,
    MatIconModule,
    MatGridListModule
];

@NgModule({
    exports: [...modules],
    imports: [...modules],
})
export class CustomMaterialModule {}
