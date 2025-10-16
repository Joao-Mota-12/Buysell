import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import Keycloak from 'keycloak-js';

export const authGuard: CanActivateFn = (route, state) => {
  const keycloak = inject(Keycloak);
  const router = inject(Router);

  if(keycloak.authenticated) {
    return true;
  }
  else {
    router.navigate(['/']);
    return false;
  }
};
