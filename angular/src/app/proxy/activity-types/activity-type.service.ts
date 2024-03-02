import type { ActivityTypeDto, CreateUpdateActivityTypeDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ActivityTypeService {
  apiName = 'Default';
  

  create = (input: CreateUpdateActivityTypeDto) =>
    this.restService.request<any, ActivityTypeDto>({
      method: 'POST',
      url: '/api/app/activity-type',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/activity-type/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ActivityTypeDto>({
      method: 'GET',
      url: `/api/app/activity-type/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ActivityTypeDto>>({
      method: 'GET',
      url: '/api/app/activity-type',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateActivityTypeDto) =>
    this.restService.request<any, ActivityTypeDto>({
      method: 'PUT',
      url: `/api/app/activity-type/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
