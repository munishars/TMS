import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { AuthenticationService } from './authentication.service';
import { Userinfo } from '../models/userinfo';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  result: boolean;
  private bearerToken: string;
  constructor(private http: HttpClient, public authService: AuthenticationService) {
    this.bearerToken = this.authService.getBearerToken();
  }
  baseUrl: string = 'http://localhost:8085/api/user/';

  getUserById(userid: string) {
    return this.http.get<User>(this.baseUrl + userid, { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`) });
  }
  deleteUser(id: string) {
    return this.http.delete<User[]>(this.baseUrl + id, { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`) });
  }
  registerUser(user: User) {
    var userinfo: Userinfo = {
      userId: user.userId,
      username: user.username,
      password: user.password,
      fullname: user.fullname,
      contact: '',
      role: 'user',
    }
    this.result = true;

    this.authService.registerUser(userinfo)
      .subscribe(data => {
      },
        error => {
          if (error.status === 403 || error.status === 409 || error.status === 500) {
            this.result = false;
          }
        });
    if (this.result) {
      return this.http.post(this.baseUrl, user);
    }
  }
  updateUser(user: User) {
    return this.http.put(this.baseUrl + user.userId, user, { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`) });
  }

}
