using System;

namespace CinemaApp.Models
{
    public class TimeSlotViewModel
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public int MovieID { get; set; }
        public int CinemaRoomID { get; set; }
    }
}
