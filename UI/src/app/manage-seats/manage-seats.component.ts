import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'manage-seats',
  templateUrl: './manage-seats.component.html',
  styleUrls: ['./manage-seats.component.scss'],
})
export class ManageSeatsComponent {
  addSeatForm: FormGroup;
  deleteSeatForm: FormControl;

  addMsg: string = '';
  delMsg: string = '';

  constructor(private fb: FormBuilder, private api: ApiService) {
    this.addSeatForm = fb.group({
      seatName: fb.control('', [Validators.required]),
      route: fb.control('', [Validators.required]),
      train: fb.control('', [Validators.required]),
      price: fb.control('', [Validators.required]),
    });

    this.deleteSeatForm = fb.control('', [Validators.required]);
  }

  insertSeat() {
    let seat = {
      id: 0,
      seatName: this.SeatName.value,
      route: {
        route: this.Route.value,
        train: this.Train.value,
      },
      price: this.Price.value,
      available: true,
    };
    this.api.insertSeat(seat).subscribe({
      next: (res: any) => {
        this.addMsg = 'Seat Inserted';
        setInterval(() => (this.addMsg = ''), 5000);
        this.SeatName.setValue('');
        this.Route.setValue('');
        this.Train.setValue('');
        this.Price.setValue('');
      },
      error: (err: any) => console.log(err),
    });
  }

  deleteSeat() {
    let id: number = parseInt(this.deleteSeatForm.value);

    this.api.deleteSeat(id).subscribe({
      next: (res: any) => {
        if (res === 'success') {
          this.delMsg = 'Seat Deleted';
        } else {
          this.delMsg = 'Seat not found!';
        }
        setInterval(() => (this.delMsg = ''), 5000);
      },
      error: (err: any) => console.log(err),
    });
  }

  get SeatName(): FormControl {
    return this.addSeatForm.get('seatName') as FormControl;
  }
  get Route(): FormControl {
    return this.addSeatForm.get('route') as FormControl;
  }
  get Train(): FormControl {
    return this.addSeatForm.get('train') as FormControl;
  }
  get Price(): FormControl {
    return this.addSeatForm.get('price') as FormControl;
  }
}
