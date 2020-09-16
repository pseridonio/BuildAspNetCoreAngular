import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RegisterService {
  baseUrl = 'http://localhost:5000/api/Authentication/';
  constructor(private http: HttpClient) {

  }

  registerNewUser(model: any) {
    console.log(model);
    return this.http.post(this.baseUrl + 'register', model);
  }
}
