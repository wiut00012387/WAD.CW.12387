using Backend._12387.Interfaces;
using Backend._12387.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace Backend._12387.DAL
{
    public class LeagueTableRepository: Repository<LeagueTable>, ILeagueTableRepository
    {
        private readonly FootballContext _context;
        private readonly DbSet<LeagueTable> _dbSet;

        public LeagueTableRepository(FootballContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<LeagueTable>();
        }

        public async Task<IEnumerable<LeagueTable>> GetLeagueTableByLeague(int leagueId, params Expression<Func<LeagueTable, object>>[] foreignKeyProperties)
        {
            if (foreignKeyProperties != null)
            {

                var query = _dbSet.Where(t => t.League.LeagueId == leagueId).AsQueryable();

                foreach (var foreignKeyProperty in foreignKeyProperties)
                {
                    query = query.Include(foreignKeyProperty);
                }

                return await query.ToListAsync();
            }
            else
            {
                return await _dbSet.ToListAsync();
            }
        }

        public virtual async Task<LeagueTable> GetLeagueTableByIdAsync(int id, params Expression<Func<LeagueTable, object>>[] foreignKeyProperties)
        {
            var query = _dbSet.AsQueryable().Where(e => e.LeagueTableId == id);

            foreach (var foreignKeyProperty in foreignKeyProperties)
            {
                query = query.Include(foreignKeyProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(LeagueTable leagueTable)
        {
            var existingLeague = await _context.Leagues.FindAsync(leagueTable.League.LeagueId);
            if (existingLeague == null)
            {
                throw new ArgumentException($"Invalid league ID {leagueTable.League.LeagueId}");
            }

            var existingClub = await _context.Clubs.FindAsync(leagueTable.Club.ClubId);
            if (existingClub == null)
            {
                throw new ArgumentException($"Invalid club ID {leagueTable.Club.ClubId}");
            }

            leagueTable.League = existingLeague;
            leagueTable.Club = existingClub;
            await _dbSet.AddAsync(leagueTable);
        }
    }
}
