import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared.module';
import { CommonModule } from '@angular/common';
import { MeService } from '../../services/me-service/me-service';
import Keycloak from 'keycloak-js';

@Component({
  standalone: true,
  selector: 'app-sidebar',
  imports: [SharedModule, RouterModule, CommonModule],
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.css'],
})
export class Sidebar {
  public isAdmin = true;

  public constructor(meService: MeService, private keycloak: Keycloak) {
      meService.getMeObservable().subscribe({
        next: (me) => {
          this.isAdmin = me?.isAdmin;
          console.log(me)
          console.log("admin:" + this.isAdmin);
        }
    })
  }

  @Output() menuClick = new EventEmitter<string>();

  selectMenu(menu: string) {
    console.log(`Menu selected: ${menu}`);
    this.menuClick.emit(menu);
  }

  logout() {
    this.keycloak.logout({ redirectUri: window.location.origin });;
  }
}
