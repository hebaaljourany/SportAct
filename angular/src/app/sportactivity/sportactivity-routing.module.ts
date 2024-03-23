import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SportActivityComponent } from './sportactivity.component';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';


const routes: Routes = [{ path: '', component: SportActivityComponent, canActivate: [AuthGuard, PermissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SportactivityRoutingModule { }
