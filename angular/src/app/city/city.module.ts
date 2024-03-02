
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { CityRoutingModule } from './city-routing.module';
import { CityComponent } from './city.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [CityComponent],
  imports: [
    CityRoutingModule,
    SharedModule,
    NgbDatepickerModule
  ]
})
export class CityModule { }
