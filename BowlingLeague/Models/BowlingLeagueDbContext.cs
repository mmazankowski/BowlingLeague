using System;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Models
{
    public class BowlingLeagueDbContext : DbContext 
    {
        public BowlingLeagueDbContext(DbContextOptions<BowlingLeagueDbContext> options) : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
