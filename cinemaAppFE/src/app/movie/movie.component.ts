import { Movie } from './../models/movie';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html'
})
export class MovieComponent {
  @Input() movie: Movie;
  @Input() timeSlot: string[][];
}
