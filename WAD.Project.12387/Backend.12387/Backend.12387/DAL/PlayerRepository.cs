using Backend._12387.Interfaces;
using Backend._12387.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Backend._12387.DAL
{
    public class PlayerRepository: Repository<Player>, IPlayerRepository
    {
        private readonly FootballContext _context;
        private readonly DbSet<Player> _dbSet;

        public PlayerRepository(FootballContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Player>();
        }

        public virtual async Task<Player> GetPlayerByIdAsync(int id, params Expression<Func<Player, object>>[] foreignKeyProperties)
        {
            var query = _dbSet.AsQueryable().Where(e => e.PlayerId == id);

            foreach (var foreignKeyProperty in foreignKeyProperties)
            {
                query = query.Include(foreignKeyProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Player player)
        {
            var existingClub = await _context.Clubs.FindAsync(player.Club.ClubId);
            if (existingClub == null)
            {
                throw new ArgumentException($"Invalid club ID {player.Club.ClubId}");
            }

            player.Club = existingClub;
            await _dbSet.AddAsync(player);
        }
    }
}
