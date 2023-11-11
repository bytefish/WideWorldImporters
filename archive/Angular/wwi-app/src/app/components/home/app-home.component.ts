// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Component } from '@angular/core';
import { TranslationService } from 'src/app/services/translation.service';

@Component({
  selector: 'app-home',
  templateUrl: 'app-home.component.html',
})
export class HomeComponent {

  constructor(public translations: TranslationService) {

  }
}