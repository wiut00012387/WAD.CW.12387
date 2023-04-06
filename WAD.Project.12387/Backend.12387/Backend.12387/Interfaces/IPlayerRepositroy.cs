using Backend._12387.Model;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Backend._12387.Interfaces
{
    public interface IPlayerRepository: IRepository<Player>
    {
        Task<Player> GetPlayerByIdAsync(int id, params Expression<Func<Player, object>>[] foreignKeyProperties);
        Task CreateAsync(Player player);
    }
}
