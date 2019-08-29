import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SidenavMenuComponent } from './navigation/sidenav-menu/sidenav-menu.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListTripAdminComponent } from './list-trip-admin/list-trip-admin.component';
import { ListTripEmployeeComponent } from './list-trip-employee/list-trip-employee.component';
import { Routes, ActivatedRouteSnapshot, RouterStateSnapshot, RouterModule } from '@angular/router';
import { RouterService } from './services/router.service';
import { AuthenticationService } from './services/authentication.service';
import { UserService } from './services/user.service';
import { HeaderComponent } from './header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule, MatDialog, MatDialogModule, MatIconModule, MatListModule } from '@angular/material';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { HttpClientModule } from '@angular/common/http';
import { RegisterUserComponent } from './register-user/register-user.component';
const appRoutes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent
  }, 
  {
    path: 'register-user',
    component: RegisterUserComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: ['CanActivateRouteGuard'],
    children: [
      {
        path: 'view/list-trip-admin',
        component: ListTripAdminComponent
      },
      {
        path: 'view/list-trip-employee',
        component: ListTripEmployeeComponent
      }
    ]
  }
];
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    SidenavMenuComponent,
    HeaderComponent,
    ListTripAdminComponent,
    ListTripEmployeeComponent,
    RegisterUserComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatExpansionModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    HttpClientModule,
    MatDialogModule,
    MatSidenavModule,
    MatListModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [{
    provide: 'CanActivateRouteGuard',
    useValue: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => true
  },RouterService, AuthenticationService,  UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
