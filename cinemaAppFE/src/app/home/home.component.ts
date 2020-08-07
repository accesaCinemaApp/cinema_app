import { MovieComponent } from './../movie/movie.component';
import { MovieService } from './../movie.service';
import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../movie';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [MovieService],
})
export class HomeComponent implements OnInit {
  movies: Movie[];
  constructor(private movieService: MovieService,private movieComponent:MovieComponent) { }

  ngOnInit() { this.getMovieList(); }

  getMovieList(): void {
    this.movieService.getMovies().subscribe(movies =>(this.movies = movies));
  }
}
