using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Data;
using Football.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Football.core
{
    public class FootballService : IFootballService
    {
        private readonly IRepository<Teams> _teamRepository;
        private readonly IRepository<Matches> _matchRepository;

        public FootballService(IRepository<Teams> teamRepository,IRepository<Matches> matchRepository)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
        }
        public async Task AddTeam(Teams team)
        {
            await _teamRepository.AddAsync(team);
        }

        public async Task UpdateTeam(Teams team)
        {
            await _teamRepository.UpdateAsync(team);
        }

        public async Task AddMatch(Matches match)
        {
            await _matchRepository.AddAsync(match);
        }

        public IEnumerable<Matches> GetMatchesByTeamId(int teamId)
        {
            return _matchRepository.GetAll().Where(t => 
                    t.HomeNavigation.ID == teamId 
                ||  t.GuestNavigation.ID==teamId)
                .Include(t=> t.HomeNavigation)
                .Include(g=> g.GuestNavigation)
                .ToList();
        }
        public IEnumerable<Teams> GelAllTeams()
        {
            return _teamRepository.GetAll().ToList();
        }
        public IEnumerable<Matches> GetAllMatches()
        {
            return _matchRepository.GetAll().ToList();
        }
    }
}
