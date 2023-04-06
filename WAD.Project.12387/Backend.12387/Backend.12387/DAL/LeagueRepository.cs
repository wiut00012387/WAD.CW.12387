using Backend._12387.Interfaces;
using Backend._12387.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Backend._12387.DAL
{
    public class LeagueRepository: Repository<League>, ILeagueRepository
    {
        private readonly FootballContext _context;
        private readonly DbSet<League> _dbSet;

        public LeagueRepository(FootballContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<League>();
        }

        public async Task DeleteLeagueAsync(int id)
        {
            var league = await GetByIdAsync(id);

            if (league == null)
            {
                throw new InvalidOperationException($"No league with ID found {id}");
            }

            var clubs = _context.Clubs.Where(b => b.League.LeagueId == id);

            if (clubs.Any())
            {
                foreach(var club in clubs)
                {
                    club.League = null;
                }
            }

            var leagueTables = _context.LeagueTables.Where(b => b.League.LeagueId == id);

            if (leagueTables.Any())
            {
               foreach(var table in  leagueTables)
                {
                    table.League = null;
                }
            }

            _dbSet.Remove(league);
        }

        public async Task CreateAsync(League league)
        {
            await _dbSet.AddAsync(league);
        }
    }
}
