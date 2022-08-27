// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MenuItem } from './models/menu-item';
import { MenuService } from './services/menu.service';
import { TranslationService } from './services/translation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  sidenavMenu$: Observable<MenuItem[]> = of([]);
  headerMenu$: Observable<MenuItem[] >= of([]);
  dropdownMenu$: Observable<MenuItem[]> = of([]);

  constructor(public menuItemService: MenuService, public translations: TranslationService) {
  }

  ngOnInit(): void {
    this.sidenavMenu$ = this.menuItemService.sidenav();
    this.headerMenu$ = this.menuItemService.header();
    this.dropdownMenu$ = this.menuItemService.dropdown();
  }

  getChildren(menuItem: MenuItem): MenuItem[] | undefined {
    return menuItem.children;
  }
}