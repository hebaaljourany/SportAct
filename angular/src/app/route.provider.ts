import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/sport-activity',
        name: '::Menu:Sport-Activity',
        //iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/Clients',
        name: '::Menu:Clients',
        parentName: '::Menu:Sport-Activity',
        layout: eLayoutType.application,
      },
      {
        path: '/cities',
        name: '::Menu:Cities',
        parentName: '::Menu:Sport-Activity',
        layout: eLayoutType.application,
      },
      {
        path: '/locations',
        name: '::Menu:Locations',
        parentName: '::Menu:Sport-Activity',
        layout: eLayoutType.application,
      },
      {
        path: '/sportactivities',
        name: '::Menu:SportActivities',
        parentName: '::Menu:Sport-Activity',
        layout: eLayoutType.application,
      },
      {
        path: '/activitytypes',
        name: '::Menu:ActivityTypes',
        parentName: '::Menu:Sport-Activity',
        layout: eLayoutType.application,
      },
      {
        path: '/reservations',
        name: '::Menu:Reservations',
        parentName: '::Menu:Sport-Activity',
        layout: eLayoutType.application,
      },

      
    ]);
  };
}
