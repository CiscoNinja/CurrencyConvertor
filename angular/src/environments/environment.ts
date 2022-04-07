import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'CurrencyConvertor',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44381',
    redirectUri: baseUrl,
    clientId: 'CurrencyConvertor_App',
    responseType: 'code',
    scope: 'offline_access CurrencyConvertor',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44381',
      rootNamespace: 'CurrencyConvertor',
    },
  },
} as Environment;
