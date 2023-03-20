import { Component } from '@angular/core';
import { SideNavItem } from '../models/models';

@Component({
  selector: 'side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss'],
})
export class SideNavComponent {
  sideNavContent: SideNavItem[] = [
    {
      title: 'view seats',
      link: 'seats/ticketing',
    },
    // {
    //   title: 'manage seats',
    //   link: 'seats/maintenance',
    // },
    {
      title: 'manage routes',
      link: 'seats/routes',
    },
    {
      title: 'return seat',
      link: 'seats/return',
    },
    {
      title: 'view users',
      link: 'users/list',
    },
    {
      title: 'all orders',
      link: 'users/all-orders',
    },
    {
      title: 'my orders',
      link: 'users/order',
    },
  ];
}
