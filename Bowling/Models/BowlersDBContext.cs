using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models
{
    public class BowlersDBContext : DbContext
    {
        public BowlersDBContext(DbContextOptions<BowlersDBContext> options) : base(options)
        {

        }
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
