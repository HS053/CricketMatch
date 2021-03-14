using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketMatch.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; } // this is player id
        public string PlayerFname { get; set; } // this is player first name
        public string PlayerLname { get; set; } // this is player last name
        public string DoB { get; set; } // this is player date of birth
        public string Address { get; set; } // this is player addresss
    }
}
