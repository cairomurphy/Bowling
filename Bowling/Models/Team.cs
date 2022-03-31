using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
    }
}
