import { Seat } from "./seat";

export interface CinemaRoom {
  id: number;
  roomNr: number;
  seats: Seat[];
}