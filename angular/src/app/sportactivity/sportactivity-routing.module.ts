import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SportActivityComponent } from './sportactivity.component';

const routes: Routes = [{ path: '', component: SportActivityComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SportactivityRoutingModule { }
