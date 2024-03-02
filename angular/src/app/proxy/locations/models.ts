import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CityLookupDto extends EntityDto<string> {
  cityName?: string;
}

export interface CreateUpdateLocationDto {
  locationName: string;
  cityId?: string;
}

export interface LocationDto extends AuditedEntityDto<string> {
  locationName?: string;
  cityId?: string;
  cityName?: string;
}
