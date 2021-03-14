using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketMatch.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; } // event id for event section

        public string Eventname { get; set; } // enter each event name

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } // starting date for each event

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } // ending date for each event
        public string EventDuration { get; set; } // durations of events

    }
}
