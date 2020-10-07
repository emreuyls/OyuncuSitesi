using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class Rank
    {
        public int ID { get; set; }
        public string Ranks { get; set; }

        public List<GameRank> GameRanks { get; set; }
        public List<AdvertRank> AdvertRanks { get; set; }
    }
}
