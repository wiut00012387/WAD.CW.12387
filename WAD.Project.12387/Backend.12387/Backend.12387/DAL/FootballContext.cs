using Backend._12387.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend._12387.DAL
{
    public class FootballContext: DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> o) : base(o)
        {
            Database.EnsureCreated();
        }

        // Database Tables
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueTable> LeagueTables { get; set; }
    }
}
