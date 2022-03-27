using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public class EFBowlingLeagueRepository : IBowlingLeagueRepository
    {
        public BowlingLeagueDbContext _repo { get; set; }

        public EFBowlingLeagueRepository(BowlingLeagueDbContext temp)
        {
            _repo = temp;
        }

        public IQueryable<Bowler> Bowlers => _repo.Bowlers;


        public void Save(Bowler b)
        {
            _repo.SaveChanges();
        }

        public void Add(Bowler b)
        {
            _repo.Add(b);
            _repo.SaveChanges();
        }

        public void Delete(Bowler b)
        {
            _repo.Remove(b);
            _repo.SaveChanges();
        }
    }
}
