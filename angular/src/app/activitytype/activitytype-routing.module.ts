import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityTypeComponent } from './activitytype.component';

const routes: Routes = [{ path: '', component: ActivityTypeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActivitytypeRoutingModule { }
