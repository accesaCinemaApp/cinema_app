import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TimeSlot } from './../models/timeSlot';
@Injectable({
  providedIn: 'root'
})

export class TimeSlotService {
  private url: string = 'http://localhost:5000/api/TimeSlots/';
  constructor(private http: HttpClient) { }

  getTimeSlots = (date: string) => this.http.get<TimeSlot[]>(this.url + date);
  getTimeSlot = (id: number) => this.http.get<TimeSlot>(this.url + id);
}
