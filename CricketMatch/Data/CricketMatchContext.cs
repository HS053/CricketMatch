using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CricketMatch.Models;

namespace CricketMatch.Data
{
    public class CricketMatchContext : DbContext
    {
        public CricketMatchContext (DbContextOptions<CricketMatchContext> options)
            : base(options)
        {
        }

        public DbSet<CricketMatch.Models.Event> Event { get; set; }

        public DbSet<CricketMatch.Models.Player> Player { get; set; }

        public DbSet<CricketMatch.Models.Fixture> Fixture { get; set; }

        public DbSet<CricketMatch.Models.Ranking> Ranking { get; set; }
    }
}
