import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movie } from './movie';
@Injectable({
  providedIn: 'root'
})

export class MovieService {
  url = 'https://jsonblob.com/api/jsonBlob/705c48f9-d328-11ea-bb09-0f382a79b1ad';
  constructor(private http: HttpClient) { }
  getMovies() {
    return this.http.get<Movie[]>(this.url);
  }

}
