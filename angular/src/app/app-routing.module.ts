import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'Clients', loadChildren: () => import('./client/client.module').then(m => m.ClientModule) },
  { path: 'cities', loadChildren: () => import('./city/city.module').then(m => m.CityModule) },
  { path: 'locations', loadChildren: () => import('./location/location.module').then(m => m.LocationModule) },
  { path: 'sportactivities', loadChildren: () => import('./sportactivity/sportactivity.module').then(m => m.SportactivityModule) },
  { path: 'activitytypes', loadChildren: () => import('./activitytype/activitytype.module').then(m => m.ActivitytypeModule) },
  { path: 'reservations', loadChildren: () => import('./reservation/reservation.module').then(m => m.ReservationModule) },
  { path: 'clients', loadChildren: () => import('./client/client.module').then(m => m.ClientModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
