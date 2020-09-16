import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  isRegisterModeOn = false;
  values: any = {};

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    
  }

  registerToogle() {
    this.isRegisterModeOn = !this.isRegisterModeOn;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.isRegisterModeOn = registerMode;
  }

}
