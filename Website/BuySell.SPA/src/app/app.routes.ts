import { Routes } from '@angular/router';
import { ProductList } from './components/product-list/product-list';
import { Home } from './components/home/home';

export const routes: Routes = [
  {
    path: '',
    component: Home
  },
  {
    path: 'products',
    component: ProductList
  }
];
