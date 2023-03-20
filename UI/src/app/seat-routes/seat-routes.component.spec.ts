import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatRoutesComponent } from './seat-routes.component';

describe('SeatRoutesComponent', () => {
  let component: SeatRoutesComponent;
  let fixture: ComponentFixture<SeatRoutesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatRoutesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeatRoutesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
