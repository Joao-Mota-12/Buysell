import { Routes } from '@angular/router';
import { ProductList } from './components/product-list/product-list';
import { Home } from './components/home/home';
import { authGuard } from './guards/auth/auth-guard';
import { Entry } from './components/entry/entry';
import { Unauthorized } from './components/unauthorized/unauthorized';
import { adminGuard } from './guards/auth/admin-guard';

export const routes: Routes = [
  {
    path: '',
    component: Home
  },
  {
    path: 'my/products',
    component: ProductList,
    canActivate: [authGuard]
  },
  {
    path: 'all/products',
    component: ProductList,
    canActivate: [authGuard, adminGuard]
  },
  {
    path: 'entry',
    component: Entry,
    canActivate: [authGuard]
  },
  {
    path: 'unauthorized',
    component: Unauthorized
  }
];
