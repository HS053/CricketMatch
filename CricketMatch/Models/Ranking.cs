using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketMatch.Models
{
    public class Ranking
    {
        [Key]
        public int ID { get; set; } // this is primary key
        public int PlayerID { get; set; } // this is foreign key
        public Player Player { get; set; } // this is foreign key

        public int EventID { get; set; } // this is foreign key
        public Event Event { get; set; } // this is foreign key

    }
}
