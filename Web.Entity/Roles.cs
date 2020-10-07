using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class Roles
    {
        
        public int ID { get; set; }
        public string Role { get; set; }

        public List<GameRole> GameRoles { get; set; }
        public List<AdvertRole> AdvertRoles { get; set; }
    }
}
