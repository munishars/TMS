import { Component } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Online-Travel-Management';
  showHead: boolean = false;
  userId: string;
  ngOnInit() {

  }

  constructor(private router: Router) {
    // on route change to '/login', set the variable showHead to false
    router.events.forEach((event) => {
      if (event instanceof NavigationStart) {
        this.userId = localStorage.getItem("username");
        if (event['url'] == '/login' || event['url'] == '/') {
          this.showHead = false;
        }
        else if (event['url'] == '/register-user' && (this.userId == '' || this.userId == null)) {
          this.showHead = false;
        }
        else {
          this.showHead = true;
        }
      }
    });
  }
}