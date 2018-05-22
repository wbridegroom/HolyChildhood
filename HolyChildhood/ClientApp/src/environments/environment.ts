// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  clientID: 'aab9cc8d-8fdb-47b6-8500-c8ee26587eb8',
  b2cScopes: ['openid', 'profile'],
  signUpSignInPolicy: 'B2C_1_HCCWeb',
  tenant: 'hccTenant.onmicrosoft.com',
  popup: false,
  redirectUrl: '/home'
};
