using Backend._12387.Interfaces;
using Backend._12387.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace Backend._12387.DAL
{
    public class ClubRepository: Repository<Club>, IClubRepository
    {
        private readonly FootballContext _context;
        private readonly DbSet<Club> _dbSet;

        public ClubRepository(FootballContext context) : base(context) {
            _context = context;
            _dbSet = _context.Set<Club>();
        }

        public async Task DeleteClubAsync(int id)
        {
            var club = await GetByIdAsync(id);

            if (club == null)
            {
                throw new InvalidOperationException($"No club with ID found {id}");
            }

            var players = _context.Players.Where(b => b.Club.ClubId == id);

            if (players.Any())
            {
                foreach (var player in players)
                {
                    player.Club = null;
                }
            }

            var leagueTables = _context.LeagueTables.Where(b => b.Club.ClubId == id);

            if (leagueTables.Any())
            {
                foreach (var table in leagueTables)
                {
                    table.Club = null;
                }
            }

            _dbSet.Remove(club);
        }

        public virtual async Task<Club> GetClubByIdAsync(int id, params Expression<Func<Club, object>>[] foreignKeyProperties)
        {
                var query = _dbSet.AsQueryable().Where(e => e.ClubId == id);

                foreach (var foreignKeyProperty in foreignKeyProperties)
                {
                    query = query.Include(foreignKeyProperty);
                }

                return await query.FirstOrDefaultAsync();
        }


        public async Task CreateAsync(Club club)
        {
            var existingLeague = await _context.Leagues.FindAsync(club.League.LeagueId);
            if (existingLeague == null)
            {
                throw new ArgumentException($"Invalid league ID {club.League.LeagueId}");
            }

            club.League = existingLeague;
            await _dbSet.AddAsync(club);
        }
    }
}
