using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }
    }
}
