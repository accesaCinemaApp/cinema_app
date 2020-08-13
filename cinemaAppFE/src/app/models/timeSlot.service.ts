import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TimeSlot } from './timeSlot';
@Injectable({
  providedIn: 'root'
})

export class TimeSlotService {
  private url: string = 'http://localhost:5000/api/TimeSlots/';
  constructor(private http: HttpClient) { }

  getTimeSlots = (date: string) => this.http.get<TimeSlot[]>(this.url + date, {
      headers: new HttpHeaders().set('Access-Control-Allow-Origin', '*'),
    });
}
