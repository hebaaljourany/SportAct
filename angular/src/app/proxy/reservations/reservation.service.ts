import type { ClientLookupDto, CreateUpdateReservationDto, ReservationDto, SportActivityLookupDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ReservationService {
  apiName = 'Default';
  

  create = (input: CreateUpdateReservationDto) =>
    this.restService.request<any, ReservationDto>({
      method: 'POST',
      url: '/api/app/reservation',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/reservation/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ReservationDto>({
      method: 'GET',
      url: `/api/app/reservation/${id}`,
    },
    { apiName: this.apiName });
  

  getClientLookup = () =>
    this.restService.request<any, ListResultDto<ClientLookupDto>>({
      method: 'GET',
      url: '/api/app/reservation/client-lookup',
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ReservationDto>>({
      method: 'GET',
      url: '/api/app/reservation',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
  

  getSportActivityLookup = () =>
    this.restService.request<any, ListResultDto<SportActivityLookupDto>>({
      method: 'GET',
      url: '/api/app/reservation/sport-activity-lookup',
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateReservationDto) =>
    this.restService.request<any, ReservationDto>({
      method: 'PUT',
      url: `/api/app/reservation/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
