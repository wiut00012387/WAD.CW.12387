using Backend._12387.Model;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Backend._12387.Interfaces
{
    public interface ILeagueTableRepository: IRepository<LeagueTable>
    {
        Task<IEnumerable<LeagueTable>> GetLeagueTableByLeague(int leagueId, params Expression<Func<LeagueTable, object>>[] foreignKeyProperties);
        Task<LeagueTable> GetLeagueTableByIdAsync(int id, params Expression<Func<LeagueTable, object>>[] foreignKeyProperties);
        Task CreateAsync(LeagueTable leagueTable);
    }
}
