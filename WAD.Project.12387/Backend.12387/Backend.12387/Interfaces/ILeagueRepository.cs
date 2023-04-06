using Backend._12387.Model;
using System.Threading.Tasks;

namespace Backend._12387.Interfaces
{
    public interface ILeagueRepository: IRepository<League>
    {
        Task DeleteLeagueAsync(int id);
        Task CreateAsync(League league);
    }
}
