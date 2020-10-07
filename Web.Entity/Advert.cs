using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class Advert
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Nick { get; set; } //oyun içi nicki
        public string Rank { get; set; } //oyundaki rütbesi veya leveli
        public string MinAge { get; set; } 
        public string Role { get; set; } //ya aradığı yada oynadığı rol olabilir
        public string Content { get; set; }
        public DateTime AdDate { get; set; }
        public Games Games { get; set; }

        public virtual List<AdvertRank> AdvertRanks { get; set; }
        public virtual List<AdvertRole> AdvertRoles { get; set; }

    }
}
