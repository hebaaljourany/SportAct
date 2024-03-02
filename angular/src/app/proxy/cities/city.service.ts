import type { CityDto, CreateUpdateCityDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CityService {
  apiName = 'Default';
  

  create = (input: CreateUpdateCityDto) =>
    this.restService.request<any, CityDto>({
      method: 'POST',
      url: '/api/app/city',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/city/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, CityDto>({
      method: 'GET',
      url: `/api/app/city/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CityDto>>({
      method: 'GET',
      url: '/api/app/city',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateCityDto) =>
    this.restService.request<any, CityDto>({
      method: 'PUT',
      url: `/api/app/city/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
