import type { AuditedEntityDto } from '@abp/ng.core';

export interface CityDto extends AuditedEntityDto<string> {
  cityName?: string;
}

export interface CreateUpdateCityDto {
  cityName: string;
}
