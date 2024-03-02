
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SportactivityRoutingModule } from './sportactivity-routing.module';
import {SportActivityComponent } from './sportactivity.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [SportActivityComponent],
  imports: [
    SportactivityRoutingModule,
    SharedModule,
    NgbDatepickerModule
  ]
})
export class SportactivityModule { }
