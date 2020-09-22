import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) {

  }

  ngOnInit() {

  }

  login() {
    console.log(this.model);
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in successfully')
      },
      error => {
        this.alertify.error(error)
      }
    );
  }

  isLoggedIn() {
    const token = localStorage.getItem('authToken');
    return !!token;
  }

  logout() {
    localStorage.removeItem('authToken');
    this.alertify.message('logged out successfully');
  }
}
