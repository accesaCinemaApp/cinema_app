<<<<<<< HEAD
import { MovieService } from './../movie.service';
import { Component, OnInit } from '@angular/core';
=======
import { MovieComponent } from './../movie/movie.component';
import { MovieService } from './../movie.service';
import { Component, OnInit, Input } from '@angular/core';
>>>>>>> f4d2c61... Added service, pages, navigation
import { Movie } from '../movie';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
<<<<<<< HEAD
  providers: [MovieService]
})
export class HomeComponent implements OnInit {
  movies: Movie[];
  constructor(private movieService: MovieService) { }
=======
  providers: [MovieService,MovieComponent],
})
export class HomeComponent implements OnInit {
  movies: Movie[];
  constructor(private movieService: MovieService,private movieComponent:MovieComponent) { }
>>>>>>> f4d2c61... Added service, pages, navigation

  ngOnInit() { this.getMovieList(); }

  getMovieList(): void {
<<<<<<< HEAD
    this.movieService.getMovies().subscribe(movies => (this.movies = movies));
=======
    this.movieService.getMovies().subscribe(movies =>(this.movies = movies));
>>>>>>> f4d2c61... Added service, pages, navigation
  }
}
