import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'return-seat',
  templateUrl: './return-seat.component.html',
  styleUrls: ['./return-seat.component.scss'],
})
export class ReturnSeatComponent {
  status: string = '';
  seatForm: FormGroup;

  constructor(private api: ApiService, private fb: FormBuilder) {
    this.seatForm = this.fb.group({
      seatId: fb.control('', [Validators.required]),
      userId: fb.control('', [Validators.required]),
    });
  }

  returnSeat() {
    let seat = (this.seatForm.get('seatId') as FormControl).value;
    let user = (this.seatForm.get('userId') as FormControl).value;
    this.api.returnSeat(seat, user).subscribe({
      next: (res: any) => {
        if (res === 'success') this.status = 'Seat Returned!';
        else this.status = res;
      },
      error: (err: any) => console.log(err),
    });
  }
}
