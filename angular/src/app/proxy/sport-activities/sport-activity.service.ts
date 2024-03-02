import type { ActivityTypeLookupDto, CreateUpdateSportActivityDto, LocationLookupDto, SportActivityDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SportActivityService {
  apiName = 'Default';
  

  create = (input: CreateUpdateSportActivityDto) =>
    this.restService.request<any, SportActivityDto>({
      method: 'POST',
      url: '/api/app/sport-activity',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/sport-activity/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, SportActivityDto>({
      method: 'GET',
      url: `/api/app/sport-activity/${id}`,
    },
    { apiName: this.apiName });
  

  getActivityTypeLookup = () =>
    this.restService.request<any, ListResultDto<ActivityTypeLookupDto>>({
      method: 'GET',
      url: '/api/app/sport-activity/activity-type-lookup',
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<SportActivityDto>>({
      method: 'GET',
      url: '/api/app/sport-activity',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
  

  getLocationLookup = () =>
    this.restService.request<any, ListResultDto<LocationLookupDto>>({
      method: 'GET',
      url: '/api/app/sport-activity/location-lookup',
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateSportActivityDto) =>
    this.restService.request<any, SportActivityDto>({
      method: 'PUT',
      url: `/api/app/sport-activity/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
