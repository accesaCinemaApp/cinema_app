using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class BookingViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int TimeSlotID { get; set; }
        public List<int> BookedSeatIDs { get; set; }
    }
}
