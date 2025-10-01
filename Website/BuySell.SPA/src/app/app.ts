import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router } from "@angular/router";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  public constructor(private router: Router) {}

  protected readonly title = signal('BuySell.SPA');

  public goToProducts() {
    this.router.navigate(['/products']);
  }
}
