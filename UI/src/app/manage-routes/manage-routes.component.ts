import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Route, RouteSeats, Seat } from '../models/models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'manage-routes',
  templateUrl: './manage-routes.component.html',
  styleUrls: ['./manage-routes.component.scss'],
})
export class ManageRoutesComponent  implements OnInit {
  routes: RouteSeats[] = [];
  columnsToDisplay: string[] = [
    'id',
    'train',
    'route',
    'active',
    'action',
  ];
  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.api.getRoutes().subscribe({
      next: (res: RouteSeats[]) => {
        this.routes = [];
        this.routes = res;
      },
      error: (err: any) => console.log(err),
    });
}
  activeRoute(routes: RouteSeats) {
     // get the current date and time
  // const currentDate = new Date();
  // const currentHour = currentDate.getHours();
  
  // // check if the current hour is after 12am (i.e. midnight)
  // if (currentHour >= 0 && currentHour < 12) {
  //   // set the active state to false
  //   routes.active = false;
  //   return;
  //}
    if (routes.active) {
      this.api.InactiveRoute(routes.id).subscribe({
        next: (res: any) => {
          if (res === 'success') routes.active = false;
        },
        error: (err: any) => console.log(err),
      });
    } else {
      this.api.activeRoute(routes.id).subscribe({
        next: (res: any) => {
          if (res === 'success') routes.active = true;
        },
        error: (err: any) => console.log(err),
      });
    }
  }
}



// {
//   routeForm: FormGroup;
//   msg: string = '';

//   constructor(private fb: FormBuilder, private api: ApiService) {
//     this.routeForm = this.fb.group({
//       route: this.fb.control(''),
//       train: this.fb.control(''),
//     });
//   }

//   addNewRoute() {
//     let c = this.Route.value;
//     let s = this.Train.value;

//     this.api.insertTrain(c, s).subscribe({
//       next: (res: any) => {
//         this.msg = res.toString();
//         setInterval(() => (this.msg = ''), 5000);
//       },
//       error: (err: any) => {
//         console.log(err);
//       },
//     });
//   }

//   get Route(): FormControl {
//     return this.routeForm.get('route') as FormControl;
//   }
//   get Train(): FormControl {
//     return this.routeForm.get('train') as FormControl;
//   }
// }
