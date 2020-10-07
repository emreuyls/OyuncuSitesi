using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
    public class GameRank
    {
        public int RankID { get; set; }
        public Rank Rank { get; set; }

        public int GamesID { get; set; }
        public Games Games { get; set; }
    }
}
