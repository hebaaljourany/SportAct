import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface ClientLookupDto extends EntityDto<string> {
}

export interface CreateUpdateReservationDto {
  sportActivityId?: string;
  clientId?: string;
}

export interface ReservationDto extends AuditedEntityDto<string> {
  sportActivityId?: string;
  activityName?: string;
  clientId?: string;
}

export interface SportActivityLookupDto extends EntityDto<string> {
  activityName?: string;
}
