<<<<<<< HEAD
import { Component } from '@angular/core';

=======
import { Movie } from './../movie';
import { Component,Input } from '@angular/core';
>>>>>>> f4d2c61... Added service, pages, navigation
@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent {
<<<<<<< HEAD
=======
 @Input() movie:Movie;

>>>>>>> f4d2c61... Added service, pages, navigation
}
