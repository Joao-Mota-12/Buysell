import { provideKeycloak, createInterceptorCondition, withAutoRefreshToken, AutoRefreshTokenService, UserActivityService, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, IncludeBearerTokenCondition } from 'keycloak-angular';

// const localhostCondition = createInterceptorCondition<IncludeBearerTokenCondition>({
//   urlPattern: /^(http:\/\/localhost:8080)(\/.*)?$/i
// });

// export const provideKeycloakAngular = () =>
//   provideKeycloak({
//     config: {
//       realm: 'master',
//       url: 'http://localhost:8080',
//       clientId: 'angular-client'
//     },
//     initOptions: {
//       onLoad: 'check-sso',
//       silentCheckSsoRedirectUri: window.location.origin + '/assets/silent-check-sso.html',
//     },
//     features: [
//       withAutoRefreshToken({
//         onInactivityTimeout: 'logout',
//         sessionTimeout: 60000
//       })
//     ],
//     providers: [
//       AutoRefreshTokenService,
//       UserActivityService,
//       {
//         provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG,
//         useValue: [localhostCondition]
//       }
//     ]
//   });
