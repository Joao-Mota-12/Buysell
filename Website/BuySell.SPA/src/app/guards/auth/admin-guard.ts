import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { MeService } from '../../services/me-service/me-service';
import { map } from 'rxjs';

export const adminGuard: CanActivateFn = (route, state) => {
  const meService = inject(MeService);
  const router = inject(Router);

  return meService.GetMe().pipe(
    map(me => {
      if(me.isAdmin) {
        return true;
      }
      else{
        return router.createUrlTree(['/unauthorized']);
      }
    })
  );
};
