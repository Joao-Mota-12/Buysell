import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'https://localhost:7098/api/Products';

  constructor(private http: HttpClient) { }

  public  getAllProducts(): Observable<Product[]> {
    var products = this.http.get<Product[]>(this.apiUrl+"/all");
    return products;
  }

  public  getAllSellerProducts(): Observable<Product[]> {
    console.log("Fetching seller products from", this.apiUrl + "/seller");
    var products = this.http.get<Product[]>(this.apiUrl + "/seller");
    console.log("Fetched seller products:", products);
    return products;
  }
}


export enum ProductStatus {
  Available = 0,
  Sold = 1,
  Reserved = 2,
}

export interface Product {
  id: number;
  ownerId: number;
  name: string;
  description: string | null;
  price: number;
  status: ProductStatus | null;
  createdAt: Date;
  updatedAt: Date | null;
}
