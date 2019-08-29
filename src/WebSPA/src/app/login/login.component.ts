import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RouterService } from '../services/router.service';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from "@angular/router";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userid = new FormControl();
  password = new FormControl();
  submitMessage: string;
  loginForm: FormGroup;
  constructor(private routerService: RouterService, private authService: AuthenticationService, private router: Router) {
    localStorage.removeItem("username");
  }
  ngOnInit() {   
    localStorage.removeItem("username");
    this.loginForm = new FormGroup(
      {
        userid: this.userid,
        password: this.password
      });
  }
  registerUser() {
    this.router.navigate(['/register-user']);
  }
  // loginSubmit() {
  //   this.authService.authenticateUser(this.loginForm.value).subscribe(
  //     data => {
  //       this.authService.setBearerToken(data['token']);
  //       localStorage.setItem('username', this.userid.value);
  //       this.routerService.routeToDashboard();
  //     },
  //     err => {
  //       if (err.status === 403) {
  //         this.submitMessage = err.error.message;
  //       }else {
  //         this.submitMessage = err.message;
  //       }
  //     }
  //   );
  // }

  loginSubmit() {
    localStorage.setItem('username', 'admin');
    this.routerService.routeToDashboard();
  }
}
