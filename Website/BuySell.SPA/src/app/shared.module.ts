import { NgModule } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { SingleProduct } from './components/single-product/single-product';

@NgModule({
  imports: [DataViewModule, ButtonModule, CardModule, SingleProduct],
  exports: [DataViewModule, ButtonModule, CardModule, SingleProduct],
})
export class SharedModule {}
