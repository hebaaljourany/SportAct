import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'SportAct',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44381/',
    redirectUri: baseUrl,
    clientId: 'SportAct_App',
    responseType: 'code',
    scope: 'offline_access SportAct',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44381',
      rootNamespace: 'SportAct',
    },
  },
} as Environment;
