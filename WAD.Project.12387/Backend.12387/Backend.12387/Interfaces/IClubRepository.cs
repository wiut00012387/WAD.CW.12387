using Backend._12387.Model;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Backend._12387.Interfaces
{
    public interface IClubRepository: IRepository<Club>
    {
        Task<Club> GetClubByIdAsync(int id, params Expression<Func<Club, object>>[] foreignKeyProperties);
        Task CreateAsync(Club club);
        Task DeleteClubAsync(int id);
    }
}
