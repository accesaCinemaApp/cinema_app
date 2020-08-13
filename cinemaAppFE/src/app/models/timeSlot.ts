import { Movie } from "./movie";
import { CinemaRoom } from "./cinemaRoom";

export interface TimeSlot {
  id: number;
  movie: Movie;
  time: string;
  cinemaRoom: CinemaRoom;
}
