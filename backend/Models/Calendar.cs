using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    
    public class Calendar
    {
        public List<TimeSlot> TimeSlots
        {
            get; set;
        }

        public Calendar(List<TimeSlot> timeSlots)
        {
            TimeSlots = timeSlots;
        }
       
    }
}
