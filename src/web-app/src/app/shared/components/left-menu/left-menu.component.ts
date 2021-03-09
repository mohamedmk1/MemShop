import {ChangeDetectionStrategy, Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';

@Component({
    selector: 'app-left-menu',
    templateUrl: './left-menu.component.html',
    styleUrls: ['./left-menu.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LeftMenuComponent implements OnChanges {
    @Input() feature: string;

    dashboardMenuSelected: boolean;
    articlesMenuSelected: boolean;
    categorySubMenuSelected: boolean;
    providerMenuSelected: boolean;

    constructor() { this.initMenu(); }

    ngOnChanges(changes: SimpleChanges): void {
        if (!!changes.feature) {
            switch (this.feature) {
                case 'Category': {
                    this.initMenu();
                    this.articlesMenuSelected = true;
                    this.categorySubMenuSelected = true;
                    break;
                }
                case 'Provider': {
                    this.initMenu();
                    this.providerMenuSelected = true;
                    break;
                }
                default: {
                    this.initMenu();
                    this.dashboardMenuSelected = true;
                    break;
                }
            }
        }
    }

    initMenu(): void {
        this.dashboardMenuSelected = false;
        this.articlesMenuSelected = false;
        this.categorySubMenuSelected = false;
        this.providerMenuSelected = false;
    }
}
