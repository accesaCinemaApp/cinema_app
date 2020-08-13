import { Component, OnInit } from '@angular/core';
import { TimeSlotComponent } from './../timeSlot/timeSlot.component';
import { TimeSlotService } from './../models/timeSlot.service';
import { TimeSlot } from '../models/timeSlot';

@Component({
  selector: 'app-program',
  templateUrl: './program.component.html',
  styleUrls: ['./program.component.css'],
  providers: [TimeSlotService]
})
export class ProgramComponent implements OnInit {

  private months: string[] = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
  public timeSlots: TimeSlot[];
  public today: string;
  public selectedDate: string;
  public nextTenDays: Array<Object> = new Array<Object>();

  constructor(private timeSlotService: TimeSlotService) {
    let tempDate: Date = new Date();
    this.today = `${tempDate.getFullYear()}-${tempDate.getMonth()+1}-${tempDate.getDate()}`;
    
    for(let i: number = 0; i < 10; i++) {
      this.nextTenDays[i] = {
        value: `${tempDate.getFullYear()}-${tempDate.getMonth()+1}-${tempDate.getDate()}`,
        display: `${this.getMonthName(tempDate.getMonth())} ${tempDate.getDate()}`,
      };
      tempDate.setDate(tempDate.getDate() + 1);
    }
  }

  ngOnInit(): void {
    this.selectedDate = this.today;
    this.getTimeSlots(this.selectedDate);
  }

  changeDate(e: string): void {
    this.getTimeSlots(e);
  }

  getTimeSlots(date: string): void {
    this.timeSlotService.getTimeSlots(date).subscribe(timeSlots => (this.timeSlots = timeSlots));
  }

  private getMonthName(nr: number) {
    return this.months[nr];
  }

}
