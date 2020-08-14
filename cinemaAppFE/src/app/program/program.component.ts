import { Component, OnInit } from '@angular/core';
import { TimeSlotService } from './../services/timeSlot.service';
import { Movie } from './../models/movie';

@Component({
  selector: 'app-program',
  templateUrl: './program.component.html',
  styleUrls: ['./program.component.css'],
  providers: [TimeSlotService]
})
export class ProgramComponent implements OnInit {

  private months: string[] = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
  
  public today: string;
  public selectedDate: string;
  public nextTenDays: Array<Object> = new Array<Object>();

  public moviesFound: boolean;
  public movies: Map<Movie, string[][]>;

  constructor(private timeSlotService: TimeSlotService) {
    this.movies = new Map<Movie, string[][]>();
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
    this.getMovies(this.selectedDate);
  }

  changeDate(e: string): void {
    this.getMovies(e);
  }

  getMovies(date: string): void {
    this.timeSlotService.getTimeSlots(date).subscribe(
        timeSlots => {
          this.movies.clear();
          this.moviesFound = true;

          timeSlots.forEach(ts => {
            let found = false;
            [...this.movies.keys()].forEach(m => {
              // append to the previous playing hours
              if(ts.movie.id == m.id) {
                this.movies.set(m, [...this.movies.get(m), [ts.id.toString(), ts.time]]);
                found = true;
              }
            });
            // create new playing hours instance
            if (!found) {
              this.movies.set(ts.movie, [[ts.id.toString(), ts.time]]);
            }
          });
          
          // sort playing hours
          this.movies.forEach((val, key) => {
            this.movies.set(key, [...val].sort((a, b) => a[1].localeCompare(b[1])));
          });
        },
        _error => { this.moviesFound = false; this.movies.clear(); }
      );
  }

  private getMonthName(nr: number) {
    return this.months[nr];
  }

}
