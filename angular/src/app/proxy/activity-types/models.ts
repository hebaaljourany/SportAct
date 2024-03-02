import type { AuditedEntityDto } from '@abp/ng.core';

export interface ActivityTypeDto extends AuditedEntityDto<string> {
  activityTypeName?: string;
}

export interface CreateUpdateActivityTypeDto {
  activityTypeName: string;
}
