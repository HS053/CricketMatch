using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketMatch.Models
{
    public class Fixture
    {
        [Key]
        public int Fixture_Id { get; set; } // This is the primary key

        public string vs_Team { get; set; } // which team vs playing 
        public string Country { get; set; } // in which country they play match

        public DateTime Date { get; set; } // which date they play match 

        public string Ground_Name { get; set; } // in which ground they play
    }
}
