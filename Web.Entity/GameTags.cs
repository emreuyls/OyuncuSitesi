using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class GameTags
    {
        public int GamesID { get; set; }
        public Games Games { get; set; }

        public int TagsID { get; set; }
        public Tags Tags { get; set; }
    }
}
