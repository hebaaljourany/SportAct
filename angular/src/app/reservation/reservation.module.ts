
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ReservationRoutingModule } from './reservation-routing.module';
import { ReservationComponent } from './reservation.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [ReservationComponent],
  imports: [
    ReservationRoutingModule,
    SharedModule,
    NgbDatepickerModule
  ]
})
export class ReservationModule { }
