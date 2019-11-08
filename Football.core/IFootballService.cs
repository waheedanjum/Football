using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Football.Data.Model;

namespace Football.core
{
    public interface  IFootballService
    {
        Task AddTeam(Teams team);
        Task UpdateTeam(Teams team);
        Task AddMatch(Matches match);

        IEnumerable<Matches> GetMatchesByTeamId(int teamId);
        IEnumerable<Matches> GetAllMatches();
        IEnumerable<Teams> GelAllTeams();

    }
}
