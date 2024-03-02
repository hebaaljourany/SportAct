
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { LocationRoutingModule } from './location-routing.module';
import { LocationComponent } from './location.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [LocationComponent],
  imports: [
    LocationRoutingModule,
    SharedModule,
    NgbDatepickerModule
  ]
})
export class LocationModule { }
