import { Component, OnInit } from '@angular/core';
import { Card } from 'primeng/card';
import { CommonModule } from '@angular/common';
import { Product, ProductService } from '../../services/product-service';

@Component({
  selector: 'app-product-list',
  imports: [Card, CommonModule],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList implements OnInit {
  public constructor(private readonly productService: ProductService) {}

  ngOnInit(): void {
    this.getProducts();
    console.log(this.products);
  }

  public isLoading: boolean = false;
  public errorMessage: string | null = null;

  public products: Product[] = [];

  public async getProducts(): Promise<void> {
    this.isLoading = true;
    this.errorMessage = null;

    this.productService.getAllProducts().subscribe({
      next: (data: Product[]) => {
        this.products = data;
        console.log('Products successfully loaded.', this.products);
        this.isLoading = false;
      },
      error: (err) => {
        console.error('API call failed:', err);
        this.errorMessage = 'Failed to load products. Please try again later.';
        this.isLoading = false;
      },
    });
  }
}
