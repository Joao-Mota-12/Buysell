import { Component, EventEmitter, Output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared.module';

@Component({
  standalone: true,
  selector: 'app-sidebar',
  imports: [SharedModule, RouterModule],
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.css'],
})
export class Sidebar{
  @Output() menuClick = new EventEmitter<string>();


  selectMenu(menu: string) {
    console.log(`Menu selected: ${menu}`);
    this.menuClick.emit(menu);
  }

}
