using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class AdvertRole
    {
        public int AdvertID { get; set; }
        public Advert Advert { get; set; }
        public int RolesID { get; set; }
        public Roles Roles { get; set; }
    }
}
