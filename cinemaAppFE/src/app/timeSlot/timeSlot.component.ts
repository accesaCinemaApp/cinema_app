import { Component, Input } from '@angular/core';
import { TimeSlot } from '../models/timeSlot';

@Component({
  selector: 'app-timeslot',
  templateUrl: './timeSlot.component.html',
  styleUrls: ['./timeSlot.component.css']
})
export class TimeSlotComponent {
  @Input() timeSlot: TimeSlot;

}
