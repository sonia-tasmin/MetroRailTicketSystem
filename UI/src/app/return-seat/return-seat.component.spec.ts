import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnSeatComponent } from './return-seat.component';

describe('ReturnSeatComponent', () => {
  let component: ReturnSeatComponent;
  let fixture: ComponentFixture<ReturnSeatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReturnSeatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReturnSeatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
