import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { TimeSlot } from '../models/timeSlot';
import { TimeSlotService } from './../services/timeSlot.service';
import { BookingVMService } from './../services/bookingVM.service';
import { Seat } from '../models/seat';

@Component({
  selector: 'app-timeslot',
  templateUrl: './timeSlot.component.html',
  styleUrls: ['./timeSlot.component.css'],
  providers: [TimeSlotService]
})
export class TimeSlotComponent implements OnInit {
  
  public timeSlot: TimeSlot;
  public timeSlotFound: boolean;
  public wantsToBook: boolean;

  public userEmail: string;
  public timeSlotID: number;
  public seats: Seat[][];
  public bookedSeatsModel: Object = {};

  constructor(private timeSlotService: TimeSlotService,
    private bookingService: BookingVMService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.timeSlotID = parseInt(this.route.snapshot.paramMap.get('id'));
    this.timeSlotService.getTimeSlot(this.timeSlotID).subscribe(
      timeSlot => { 
        this.timeSlot = timeSlot;
        this.timeSlotFound = true;
        this.wantsToBook = false;
        this.userEmail = '';
        const sortedSeats: Seat[] = this.timeSlot.cinemaRoom.seats
          .sort((a, b) => a.nr - b.nr)
          .sort((a, b) => a.row.localeCompare(b.row));
        
        let counter = 0;
        this.bookedSeatsModel[sortedSeats[0].id] = false;
        this.seats = [[sortedSeats[0]]];
        for(let i: number = 1; i < sortedSeats.length; i++) {
          if (sortedSeats[i].row == sortedSeats[i-1].row) {
            this.seats[counter] = [...this.seats[counter], sortedSeats[i]];
          } else {
            counter += 1;
            this.seats[counter] = [sortedSeats[i]];
          }
          this.bookedSeatsModel[sortedSeats[i].id] = false;
        }
      },
      _error => { this.timeSlotFound = false; this.timeSlot = undefined; }
    );
  }

  submitForm(): void {
    // building booked seat IDs array
    let bookedSeatIDs: number[] = [];
    Object.entries(this.bookedSeatsModel).forEach(entry => {
      if (entry[1]) {
        bookedSeatIDs = [...bookedSeatIDs, parseInt(entry[0])];
      }
    });

    this.bookingService.addBooking(
      {
        email: this.userEmail,
        timeSlotID: this.timeSlotID,
        bookedSeatIDs: bookedSeatIDs
      }
    ).subscribe((resp) => {
      this.router.navigate(['../']);
    }, () => console.log('an error occured'));
  }

  toggleBookingIntent(): void {
    this.wantsToBook = !this.wantsToBook;
  }
}
