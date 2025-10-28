import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product, ProductService } from '../../services/product-service/product-service';
import { Sidebar } from '../sidebar/sidebar';
import { SharedModule } from '../../shared.module';

@Component({
  standalone: true,
  selector: 'app-product-list',
  imports: [SharedModule, CommonModule, Sidebar],
  templateUrl: './product-list.html',
  styleUrls: ['./product-list.css'],
})
export class ProductList implements OnInit {
  public constructor(private readonly productService: ProductService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getSellerProducts();
    console.log(this.products);
  }

  public productsTest : Product[] = [];

  public isLoading: boolean = false;
  public errorMessage: string | null = null;

  public products: Product[] = [];
  public productsSeller: Product[] = [];

  public async getProducts(): Promise<void> {
    this.isLoading = true;
    this.errorMessage = null;

    this.productService.getAllProducts().subscribe({
      next: (data: Product[]) => {
        this.products = data;
        console.log('Products successfully loaded.', this.products);
        this.isLoading = false;
      },
      error: (err : any) => {
        console.error('API call failed:', err);
        this.errorMessage = 'Failed to load products. Please try again later.';
        this.isLoading = false;
      },
    })
  }

  public async getSellerProducts(): Promise<void> {
    this.isLoading = true;
    this.errorMessage = null;

    this.productService.getAllSellerProducts().subscribe({
      next: (data: Product[]) => {

        this.productsSeller = data;
        console.log('ProductsSeller successfully loaded.', this.productsSeller);
        this.isLoading = false;
      },
      error: (err : any) => {
        console.error('API call failed:', err);
        this.errorMessage = 'Failed to load products. Please try again later.';
        this.isLoading = false;
      },
    });
  }
}
