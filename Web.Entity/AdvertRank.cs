using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class AdvertRank
    {
        public int AdvertID { get; set; }
        public Advert Advert { get; set; }
        public int RankID { get; set; }
        public Rank Rank { get; set; }
    }
}
