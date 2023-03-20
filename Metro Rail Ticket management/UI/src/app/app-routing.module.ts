import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { combineLatest } from 'rxjs';
import { AuthorizationGuard } from './authorization.guard';
import { AuthenticationGuard } from './guards/authentication.guard';
import { TicketingComponent } from './ticketing/ticketing.component';
import { LoginComponent } from './login/login.component';
import { ManageSeatsComponent } from './manage-seats/manage-seats.component';
import { ManageRoutesComponent } from './manage-routes/manage-routes.component';
import { OrderComponent } from './order/order.component';
import { OrdersComponent } from './orders/orders.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { ReturnSeatComponent } from './return-seat/return-seat.component';
import { UsersListComponent } from './users-list/users-list.component';

const routes: Routes = [
  {
    path: 'seats/ticketing',
    component: TicketingComponent,
    canActivate: [AuthenticationGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'users/order',
    component: OrderComponent,
    canActivate: [AuthenticationGuard],
  },
  {
    path: 'users/all-orders',
    component: OrdersComponent,
    canActivate: [AuthorizationGuard],
  },
  {
    path: 'seats/return',
    component: ReturnSeatComponent,
    canActivate: [AuthenticationGuard],
  },
  {
    path: 'users/list',
    component: UsersListComponent,
    canActivate: [AuthorizationGuard],
  },
  {
    path: 'seats/maintenance',
    component: ManageSeatsComponent,
    canActivate: [AuthorizationGuard],
  },
  {
    path: 'seats/routes',
    component: ManageRoutesComponent,
    canActivate: [AuthorizationGuard],
  },
  {
    path: 'users/profile',
    component: ProfileComponent,
    canActivate: [AuthenticationGuard],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
