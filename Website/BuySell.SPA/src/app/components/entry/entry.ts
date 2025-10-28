import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { Sidebar } from '../sidebar/sidebar';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared.module';

@Component({
  selector: 'app-entry',
  imports: [SharedModule, Sidebar, CommonModule, RouterOutlet],
  templateUrl: './entry.html',
  styleUrl: './entry.css'
})
export class Entry {
  public constructor(private router: Router) {}
  public selectedMenu: string | null = null;

  public goToProducts() {
    this.router.navigate(['/products']);
  }

  onMenuClick(menu: string) {
    console.log(`Menu clicked in Entry component: ${menu}`);
    this.selectedMenu = menu;
  }
}
