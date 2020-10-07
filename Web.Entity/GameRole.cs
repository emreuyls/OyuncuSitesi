using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class GameRole
    {
        public int GamesID { get; set; }
        public Games Games { get; set; }

        public int RolesID { get; set; }
        public Roles Roles { get; set; }
    }
}
