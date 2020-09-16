import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  model: any = {};

  constructor(private authService: AuthService) {

  }

  ngOnInit() {

  }

  login() {
    console.log(this.model);
    this.authService.login(this.model).subscribe(
      next => {
        console.log('Logged in successfully')
      },
      error => {
        console.log('Failed to login')
      }
    );
  }

  isLoggedIn() {
    const token = localStorage.getItem('authToken');
    return !!token;
  }

  logout() {
    localStorage.removeItem('authToken');
    console.log('logged out successfully');
  }
}
