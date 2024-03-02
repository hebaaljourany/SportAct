import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface ActivityTypeLookupDto extends EntityDto<string> {
  activityTypeName?: string;
}

export interface CreateUpdateSportActivityDto {
  activityName: string;
  capacity: number;
  cost: number;
  minimumAge: number;
  maximumAge: number;
  startedTime: string;
  endedTime: string;
  description: string;
  locationId?: string;
  activityTypeId?: string;
}

export interface LocationLookupDto extends EntityDto<string> {
  locationName?: string;
}

export interface SportActivityDto extends AuditedEntityDto<string> {
  activityName?: string;
  capacity: number;
  cost: number;
  minimumAge: number;
  maximumAge: number;
  startedTime?: string;
  endedTime?: string;
  description?: string;
  locationId?: string;
  locationName?: string;
  activityTypeId?: string;
  activityTypeName?: string;
}
