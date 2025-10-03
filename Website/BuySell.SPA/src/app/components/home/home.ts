import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import Keycloak from 'keycloak-js';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-home',
  imports: [ButtonModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  private readonly keycloak = inject(Keycloak);

  public constructor(private router: Router) {}
  public goToProducts() {
    this.router.navigate(['/products']);
  }

  public login() {
    this.keycloak.login();
  }
}
