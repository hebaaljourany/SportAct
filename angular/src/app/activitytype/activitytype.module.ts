
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ActivitytypeRoutingModule } from './activitytype-routing.module';
import {ActivityTypeComponent } from './activitytype.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [ActivityTypeComponent],
  imports: [
    ActivitytypeRoutingModule,
    SharedModule,
    NgbDatepickerModule
  ]
})
export class ActivitytypeModule { }
