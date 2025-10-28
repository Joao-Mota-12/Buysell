import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../../services/product-service/product-service';
import { SharedModule } from 'primeng/api';

@Component({
  selector: 'app-single-product',
  imports: [SharedModule],
  templateUrl: './single-product.html',
  styleUrl: './single-product.css'
})
export class SingleProduct implements OnInit{
ngOnInit(): void {
  console.log('Product received in ProductCard:', this.product);
}
@Input() product!: Product;
}
