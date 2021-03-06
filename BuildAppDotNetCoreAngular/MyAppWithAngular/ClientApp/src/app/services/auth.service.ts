import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/Authentication/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  constructor(private http: HttpClient) {

  }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          if (response) {
            localStorage.setItem('authToken', response.authenticationToken);
            this.decodedToken = this.jwtHelper.decodeToken(response.authenticationToken);
            console.log(this.decodedToken);
          }
        })
      );
  }

  isLoggedIn() {
    const token = localStorage.getItem('authToken');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
