﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new List<Team>();
            this.SecondaryKitTeams = new List<Team>();

        }
        public int ColorId { get; set; }

        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; }
        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
