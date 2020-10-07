using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
    public class Games
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public string Type { get; set; } // Bunu 1-sonsuz türde tablodan çek
        public string Img { get; set; }
        public List<Advert> Adverts { get; set; }
        public List<GameRole> GameRoles { get; set; }
        public List<GameRank> GameRanks { get; set; }

    }
}
