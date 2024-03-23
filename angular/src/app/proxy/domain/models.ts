import type { AuditedEntityDto } from '@abp/ng.core';

export interface ClientDto extends AuditedEntityDto<string> {
  userId?: string;
}

export interface CreateUpdateClientDto {
  firstName: string;
  lastName: string;
  emailAddress: string;
  mobileNumber: number;
}
