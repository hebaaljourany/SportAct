import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface ClientLookupDto extends EntityDto<string> {
}

export interface CreateUpdateReservationDto {
  participants: number;
  sportActivityId?: string;
  clientId?: string;
}

export interface ReservationDto extends AuditedEntityDto<string> {
  participants: number;
  sportActivityId?: string;
  activityName?: string;
  clientId?: string;
}

export interface SportActivityLookupDto extends EntityDto<string> {
  activityName?: string;
}
