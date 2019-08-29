import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { Userinfo } from '../models/userinfo';
import 'rxjs/add/operator/map';
@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {

  constructor(private httpClient: HttpClient) {
  }

  authenticateUser(data) {
    return this.httpClient.post('http://localhost:8081/auth/login/', data);
  }

  registerUser(userinfo) {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post('http://localhost:8081/auth/register/',userinfo, {headers:headers});
  }

  setBearerToken(token) {
    localStorage.setItem('bearerToken', token);
  }

  getBearerToken() {
    return localStorage.getItem('bearerToken');
  }

  getUsername() {
    return localStorage.getItem('username');
  }

  isUserAuthenticated(token): Promise<boolean> {
    return this.httpClient.post('http://localhost:8081/auth/isAuthenticated', {},
      { headers: new HttpHeaders().set('Authorization', `Bearer ${token}`) })
      .map(response => response['isAuthenticated']).toPromise();
  }
}
