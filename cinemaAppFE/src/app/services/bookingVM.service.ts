import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookingVM } from './../models/bookingVM';
@Injectable({
  providedIn: 'root'
})

export class BookingVMService {
  private url: string = 'http://localhost:5000/api/Bookings/';
  constructor(private http: HttpClient) { }

  addBooking = (booking: BookingVM) => this.http.post<BookingVM>(this.url, booking);
}