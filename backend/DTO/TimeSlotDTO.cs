using CinemaApp.Models;
using System;

namespace CinemaApp.DTO
{
    public class TimeSlotDTO
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public CinemaRoomDTO CinemaRoom { get; set; }
        public MovieDTO Movie { get; set; }

        public TimeSlotDTO() { }
        public TimeSlotDTO(TimeSlot timeSlot)
        {
            ID = timeSlot.ID;
            Time = timeSlot.Time;
            CinemaRoom = new CinemaRoomDTO(timeSlot.CinemaRoom);
            Movie = new MovieDTO(timeSlot.Movie);
        }

        public TimeSlot DTOToModel()
        {
            return new TimeSlot()
            {
                ID = ID,
                Time = Time,
                CinemaRoom = CinemaRoom.DTOToModel(),
                Movie = Movie.DTOToModel()
            };
        }
    }
}