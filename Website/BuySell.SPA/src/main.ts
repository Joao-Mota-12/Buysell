import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { inject, runInInjectionContext } from '@angular/core';
import Keycloak from 'keycloak-js';
import { MeService } from './app/services/me-service/me-service';
import { KEYCLOAK_EVENT_SIGNAL } from 'keycloak-angular';

bootstrapApplication(App, appConfig)
  .then(async appRef => {
    await runInInjectionContext(appRef.injector, async () =>{
      const keycloak = inject(Keycloak);
      const meService = inject(MeService);
      const keycloakSignal = inject(KEYCLOAK_EVENT_SIGNAL);

      const isLoggedIn = keycloak.authenticated;
      if (isLoggedIn) {
        try {
          await meService.GetMe().subscribe();
        }
        catch (error) {
          console.error('Error fetching Me', error);
        }
      }
      else {
        console.log('User is not authenticated');
      }
    })
  })
  .catch((err) => console.error(err));
