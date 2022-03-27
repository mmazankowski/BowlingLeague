using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public interface IBowlingLeagueRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public void Save(Bowler b);

        public void Add(Bowler b);

        public void Delete(Bowler b);

    }
}
