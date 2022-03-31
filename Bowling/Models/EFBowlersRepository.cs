using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDBContext _context { get; set; }
        public EFBowlersRepository(BowlersDBContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;
    }
}
