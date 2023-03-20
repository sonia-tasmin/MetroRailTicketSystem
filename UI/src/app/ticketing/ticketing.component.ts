import { Component, OnInit } from '@angular/core';
import { Seat, RouteSeats } from '../models/models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'ticketing',
  templateUrl: './ticketing.component.html',
  styleUrls: ['./ticketing.component.scss'],
})
export class TicketingComponent implements OnInit {
  availableSeats: Seat[] = [];
  seatsToDisplay: RouteSeats[] = [];
  displayedColumns: string[] = [
    'id',
    'seatName',
    'price',
    'available',
    'order',
  ];

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.api.getAllSeats().subscribe({
      next: (res: Seat[]) => {
        this.availableSeats = [];
        console.log(res);
        for (var seat of res) this.availableSeats.push(seat);
        this.updateList();
      },
      error: (err: any) => console.log(err),
    });
  }

  updateList() {
    this.seatsToDisplay = [];
    for (let seat of this.availableSeats) {
      let exist = false;
      for (let routeSeats of this.seatsToDisplay) {
        if (
          seat.route === routeSeats.route &&
          seat.train === routeSeats.train
        )
          exist = true;
      }

      if (exist) {
        for (let routeSeats of this.seatsToDisplay) {
          if (
            seat.route === routeSeats.route &&
            seat.train === routeSeats.train
          )
          routeSeats.seats.push(seat);
        }
      } else {
        this.seatsToDisplay.push({
          route: seat.route,
          train: seat.train,
          seats: [seat],
          id: 0,
          active: false
        });
      }
    }
  }

  getSeatCount() {
    return this.seatsToDisplay.reduce((pv, cv) => cv.seats.length + pv, 0);
  }

  search(value: string) {
    value = value.toLowerCase();
    this.updateList();
    if (value.length > 0) {
      this.seatsToDisplay = this.seatsToDisplay.filter((routeSeats) => {
        routeSeats.seats = routeSeats.seats.filter(
          (seat) =>
            seat.seatName.toLowerCase().includes(value)
        );
        return routeSeats.seats.length > 0;
      });
    }
  }

  orderSeat(seat: Seat) {
    let userid = this.api.getTokenUserInfo()?.id ?? 0;
    this.api.orderSeat(userid, seat.id).subscribe({
      next: (res: any) => {
        if (res === 'success') {
          seat.available = false;
        }
      },
      error: (err: any) => console.log(err),
    });
  }

}
