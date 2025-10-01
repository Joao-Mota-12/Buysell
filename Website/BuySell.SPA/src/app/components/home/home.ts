import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-home',
  imports: [ButtonModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
public constructor(private router: Router) {}
  public goToProducts() {
    this.router.navigate(['/products']);
  }
}
