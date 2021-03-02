import {ChangeDetectionStrategy, Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';

@Component({
    selector: 'app-left-menu',
    templateUrl: './left-menu.component.html',
    styleUrls: ['./left-menu.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LeftMenuComponent implements OnInit, OnChanges {

    @Input() feature: string;

    dashboardMenuSelected = false;
    articlesMenuSelected = false;
    categorySubMenuSelected = false;

    constructor() { }

    ngOnInit(): void {

    }

    ngOnChanges(changes: SimpleChanges): void {
        if (!!changes.feature) {
            switch (this.feature) {
                case 'Category': {
                    this.articlesMenuSelected = true;
                    this.categorySubMenuSelected = true;
                    this.dashboardMenuSelected = false;
                    break;
                }
                default: {
                    this.dashboardMenuSelected = true;
                    this.articlesMenuSelected = false;
                    this.categorySubMenuSelected = false;
                    break;
                }
            }
        }
    }



}
