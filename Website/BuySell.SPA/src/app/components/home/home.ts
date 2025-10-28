import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import Keycloak from 'keycloak-js';
import { SharedModule } from '../../shared.module';

@Component({
  selector: 'app-home',
  imports: [SharedModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  private readonly keycloak = inject(Keycloak);

  public constructor(private router: Router) {}

  public goToProducts() {
    this.router.navigate(['/entry']);
  }

  public login() {
    this.keycloak.login();
  }
}
